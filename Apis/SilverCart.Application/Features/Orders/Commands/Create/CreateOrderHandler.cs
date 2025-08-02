using System.Drawing;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Services.System;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Orders;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Entities.Stores;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.Create;

public class CreateOrderHandler(
    IUnitOfWork unitOfWork,
    IClaimsService claimsService
) : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClaimsService _claimService = claimsService;

    public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        (Guid currentUserId, RoleEnum? currentUserRole, BaseUser? user, IQueryable<ProductItem> productItems) = await HandleValidation(request, cancellationToken);

        (List<OrderDetails> orderDetails, Order order) = await HandleCreateOrder(request, productItems, cancellationToken);

        await HandleUserRole(currentUserId, currentUserRole, orderDetails, order);
        using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                // Create order and its details
                await _unitOfWork.OrderRepository.AddAsync(order);
                await _unitOfWork.SaveChangeAsync();

                // Update stock
                foreach (var orderItem in request.OrderItems)
                {
                    var productItem = await productItems.FirstAsync(pi => pi.Id == orderItem.ProductItemId, cancellationToken);
                    productItem.Stock.Quantity -= orderItem.Quantity;
                    _unitOfWork.ProductItemRepository.Update(productItem);
                }

                await _unitOfWork.SaveChangeAsync();
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

        var orderDetailResponses = orderDetails.Select(od =>
        {
            ProductItem productItem = productItems.First(pi => pi.Id == od.ProductItemId);
            return new CreateOrderDetailResponse(
                od.Id,
                od.ProductItemId,
                productItem.Product.Name,
                productItem.ProductName,
                od.Quantity,
                od.Price
            );
        }).ToList();

        return new CreateOrderResponse(
            order.Id,
            order.TotalPrice,
            order.FinalPrice,
            order.OrderStatus,
            order.CreationDate ?? DateTime.UtcNow,
            orderDetailResponses
        );
    }



    private async Task<(List<OrderDetails> orderDetails, Order order)> HandleCreateOrder(CreateOrderCommand request, IQueryable<ProductItem> productItems, CancellationToken cancellationToken)
    {
        decimal totalPrice = 0;
        var orderDetails = new List<OrderDetails>();

        foreach (var orderItem in request.OrderItems)
        {
            var productItem = await productItems.FirstAsync(pi => pi.Id == orderItem.ProductItemId, cancellationToken);
            var itemTotal = productItem.DiscountedPrice * orderItem.Quantity;
            totalPrice += itemTotal;

            var orderDetail = new OrderDetails
            {
                ProductItemId = orderItem.ProductItemId,
                Quantity = orderItem.Quantity,
                Price = productItem.OriginalPrice,
                Notes = orderItem.Notes,
                OrderItemStatus = OrderItemStatusEnums.Pending,
                Weight = productItem.Weight,
                Length = productItem.Length,
                Width = productItem.Width,
                Height = productItem.Height,
                OrderId = Guid.NewGuid()
            };

            orderDetails.Add(orderDetail);
        }

        var order = new Order
        {
            TotalPrice = totalPrice,
            OrderStatus = OrderStatusEnum.Pending,
            OrderCode = $"ORD{DateTime.UtcNow:yyyyMMddHHmmss}",
            FromAddress = "Cửa hàng",
            ToAddress = "Địa chỉ giao hàng",
            EarnedPoints = 0,
            UsedPoints = 0,
            PaymentStatus = new OrderPaymentStatus
            {
                Amount = totalPrice,
                PaymentDate = DateTime.UtcNow,
                PaymentMethod = request.OrderInfo.PaymentMethod,
                PaymentStatus = PaymentStatusEnum.Pending
            },
            ShippingStatus = new OrderShippingStatus
            {
                Status = ShippingStatusEnum.Pending
            },
            CreationDate = DateTime.UtcNow
        };

        order.FinalPrice = order.TotalPrice;
        if (request.Points > 0)
        {
            order.FinalPrice -= request.Points;
        }
        order.EarnedPoints = (int)(order.FinalPrice / 1000);
        return (orderDetails, order);
    }

    private async Task<(Guid currentUserId, RoleEnum? currentUserRole, BaseUser? user, IQueryable<ProductItem> productItems)> HandleValidation(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimService.CurrentUserId;
        if (currentUserId == Guid.Empty)
        {
            throw new AppExceptions("Người dùng chưa đăng nhập", 401);
        }
        var currentUserRole = _claimService.CurrentRole;
        BaseUser? user = await _unitOfWork.UserRepository.GetByIdAsync(currentUserId);
        AppExceptions.ThrowIfNotFound(user, $"{string.Join(", ", currentUserRole)} with ID {currentUserId} not found");

        if (currentUserRole != RoleEnum.Guardian && currentUserRole != RoleEnum.DependentUser)
        {
            throw new AppExceptions("Chỉ Guardian và DependentUser có thể tạo đơn hàng");
        }

        var productItemIds = request.OrderItems.Select(oi => oi.ProductItemId).ToList();
        var productItems = await _unitOfWork.ProductItemRepository.GetAllAsync(
            predicate: pi => productItemIds.Contains(pi.Id) && pi.IsActive,
            include: source => source
                .Include(pi => pi.Product)
        );

        if (await productItems.CountAsync() != productItemIds.Count)
        {
            throw new AppExceptions("Một số sản phẩm không tồn tại hoặc không hoạt động");
        }

        var stockIssues = new List<string>();
        foreach (var orderItem in request.OrderItems)
        {
            var productItem = await productItems.FirstAsync(pi => pi.Id == orderItem.ProductItemId, cancellationToken);
            if (productItem.Stock.Quantity < orderItem.Quantity)
            {
                stockIssues.Add($"Không đủ stock cho ProductName {productItem.ProductName}. Còn lại: {productItem.Stock}, Yêu cầu: {orderItem.Quantity}");
            }
        }

        if (stockIssues.Any())
        {
            throw new AppExceptions($"Vấn đề về stock: {string.Join("; ", stockIssues)}");
        }

        return (currentUserId, currentUserRole, user, productItems);
    }

    private async Task HandleUserRole(Guid currentUserId, RoleEnum? currentUserRole, List<OrderDetails> orderDetails, Order order)
    {
        if (currentUserRole == RoleEnum.Guardian)
        {
            order.OrderedUserId = currentUserId;
            order.ConfirmUserId = currentUserId;

            order.OrderStatus = OrderStatusEnum.GuardianConfirmed;

            foreach (var orderDetail in orderDetails)
            {
                orderDetail.OrderItemStatus = OrderItemStatusEnums.ConfirmedByGuardian;
            }
        }
        else if (currentUserRole == RoleEnum.DependentUser)
        {
            var dependentUser = await _unitOfWork.DependentUserRepository.GetByIdAsync(currentUserId);
            AppExceptions.ThrowIfNotFound(dependentUser, "Người dùng phụ thuộc không tồn tại");
            order.OrderedUserId = currentUserId;

            order.OrderStatus = OrderStatusEnum.Pending;

            foreach (var orderDetail in orderDetails)
            {
                orderDetail.OrderItemStatus = OrderItemStatusEnums.Pending;
            }
        }
    }

}
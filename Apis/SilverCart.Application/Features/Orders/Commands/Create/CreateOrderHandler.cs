using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Orders;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.Create;

public class CreateOrderHandler(IUnitOfWork unitOfWork, AutoMapper.IMapper mapperConfig, IClaimsService claimsService) : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClaimsService _claimService = claimsService;
    public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimService.CurrentUserId;
        if (currentUserId == Guid.Empty)
        {
            throw new AppExceptions("User not authenticated");
        }
        var currentUserRole = _claimService.CurrentRole;

        if (currentUserRole != "Guardian" && currentUserRole != "DependentUser")
        {
            throw new AppExceptions("Only Guardian and DependentUser roles can create orders");
        }

        BaseUser? user = null;
        if (currentUserRole == "Guardian")
        {
            user = await _unitOfWork.GuardianUserRepository.GetByIdAsync(currentUserId);
            if (user == null)
            {
                throw new AppExceptions($"Guardian with ID {currentUserId} not found");
            }
        }
        else if (currentUserRole == "DependentUser")
        {
            user = await _unitOfWork.DependentUserRepository.GetByIdAsync(currentUserId);
            if (user == null)
            {
                throw new AppExceptions($"Dependent user with ID {currentUserId} not found");
            }
        }

        var productItemIds = request.OrderItems.Select(oi => oi.ProductItemId).ToList();
        var productItems = await _unitOfWork.ProductItemRepository.GetAllAsync(
            predicate: pi => productItemIds.Contains(pi.Id) && pi.IsActive,
            include: source => source
                .Include(pi => pi.Variant)
                    .ThenInclude(v => v.Product)
        );

        if (await productItems.CountAsync() != productItemIds.Count)
        {
            throw new AppExceptions("Some product items not found or inactive");
        }

        var stockIssues = new List<string>();
        foreach (var orderItem in request.OrderItems)
        {
            var productItem = await productItems.FirstAsync(pi => pi.Id == orderItem.ProductItemId, cancellationToken);
            if (productItem.Stock.Quantity < orderItem.Quantity)
            {
                stockIssues.Add($"Insufficient stock for SKU {productItem.SKU}. Available: {productItem.Stock}, Requested: {orderItem.Quantity}");
            }
        }

        if (stockIssues.Any())
        {
            throw new AppExceptions($"Stock issues: {string.Join("; ", stockIssues)}");
        }

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
                Notes = orderItem.Notes
            };

            orderDetails.Add(orderDetail);
        }

        var order = new Order
        {
            TotalPrice = totalPrice,
            OrderStatus = OrderStatusEnum.Pending,
            UserPromotionId = request.UserPromotionId,
            OrderDetails = orderDetails
        };

        // Set order properties based on user role
        if (currentUserRole == "Guardian")
        {
            order.GuardianId = currentUserId;
            order.DependentUserID = null;

            order.OrderStatus = OrderStatusEnum.GuardianConfirmed;

            foreach (var orderDetail in orderDetails)
            {
                orderDetail.OrderItemStatus = OrderItemStatusEnums.ConfirmedByGuardian;
            }
        }
        else if (currentUserRole == "DependentUser")
        {
            var dependentUser = await _unitOfWork.DependentUserRepository.GetByIdAsync(currentUserId);
            if (dependentUser == null)
            {
                throw new AppExceptions("Người dùng phụ thuộc không tồn tại");
            }
            order.DependentUserID = currentUserId;
            order.GuardianId = dependentUser.GuardianId;

            order.OrderStatus = OrderStatusEnum.Pending;

            foreach (var orderDetail in orderDetails)
            {
                orderDetail.OrderItemStatus = OrderItemStatusEnums.Pending;
            }
        }

        await _unitOfWork.OrderRepository.AddAsync(order);
        await _unitOfWork.SaveChangeAsync();

        foreach (var orderItem in request.OrderItems)
        {
            var productItem = await productItems.FirstAsync(pi => pi.Id == orderItem.ProductItemId, cancellationToken);
            productItem.Stock.Quantity -= orderItem.Quantity;
            _unitOfWork.ProductItemRepository.Update(productItem);
        }

        await _unitOfWork.SaveChangeAsync();

        var orderDetailResponses = orderDetails.Select(od =>
        {
            ProductItem productItem = productItems.First(pi => pi.Id == od.ProductItemId);
            return new CreateOrderDetailResponse(
                        od.Id,
                        od.ProductItemId,
                        productItem.Variant.Product.Name,
                        productItem.Variant.VariantName,
                        productItem.SKU,
                        od.Quantity,
                        od.Price
                    );
        }).ToList();

        return new CreateOrderResponse(
            order.Id,
            order.TotalPrice,
            order.OrderStatus,
            order.CreationDate ?? DateTime.UtcNow,
            orderDetailResponses
        );
    }
}
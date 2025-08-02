using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Enums;

namespace Infrastructures;

public sealed record GetOrderByIdQuery(Guid Id) : IRequest<GetOrderByIdResponse>;
public record GetOrderByIdResponse(Guid Id, double TotalPrice, DateTime CreationDate, string OrderStatus, string ToAddress, string? FromAddress, List<GetOrderDetailsResponse> OrderDetails);
public record GetOrderDetailsResponse(Guid Id, Guid ProductItemId, int Quantity, double Price, string OrderItemStatus, GetProductItemResponse ProductItem);
public record GetProductItemResponse(Guid Id, string ProductName, double OriginalPrice, double DiscountedPrice, int Stock, bool IsActive, List<GetProductItemsImagesResponse> ProductImages);
public class GetOrderByIdQueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClaimsService _claimsService = claimsService;
    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync(
            predicate: x => x.Id == request.Id,
            include: source => source
                .Include(x => x.OrderDetails)
                    .ThenInclude(od => od.ProductItem)
                        .ThenInclude(pi => pi.Stock)
                .Include(x => x.OrderDetails)
                    .ThenInclude(od => od.ProductItem)
                        .ThenInclude(pi => pi.ProductImages)
                .Include(x => x.OrderedUser)
                    .ThenInclude(x => x.Addresses)
        );
        var order = orders.FirstOrDefault();
        if (order == null)
            throw new AppExceptions("Đơn hàng không tồn tại");

        var currentUserRole = _claimsService.CurrentRole ?? RoleEnum.Guardian;
        var isCustomerRole = currentUserRole == RoleEnum.Guardian || currentUserRole == RoleEnum.DependentUser;

        return new GetOrderByIdResponse
        (
            Id: order.Id,
            TotalPrice: (double)order.TotalPrice,
            CreationDate: order.CreationDate ?? DateTime.UtcNow,
            OrderStatus: order.OrderStatus.ToString(),
            ToAddress: order.ToAddress,
            FromAddress: isCustomerRole ? null : order.FromAddress,
            OrderDetails: order.OrderDetails.Select(orderDetail => new GetOrderDetailsResponse
            (
                Id: orderDetail.Id,
                ProductItemId: orderDetail.ProductItemId,
                Quantity: orderDetail.Quantity,
                Price: (double)orderDetail.Price,
                OrderItemStatus: orderDetail.OrderItemStatus.ToString(),
                ProductItem: new GetProductItemResponse
                (
                    Id: orderDetail.ProductItem.Id,
                    ProductName: orderDetail.ProductItem.ProductName,
                    OriginalPrice: (double)orderDetail.ProductItem.OriginalPrice,
                    DiscountedPrice: (double)orderDetail.ProductItem.DiscountedPrice,
                    Stock: orderDetail.ProductItem.Stock?.Quantity ?? 0,
                    IsActive: orderDetail.ProductItem.IsActive,
                    ProductImages: orderDetail.ProductItem.ProductImages.Select(img => new GetProductItemsImagesResponse
                    (
                        Id: img.Id,
                        ImagePath: img.ImagePath,
                        ImageName: img.ImageName
                    )).ToList()
                )
            )).ToList()
        );
    }
}

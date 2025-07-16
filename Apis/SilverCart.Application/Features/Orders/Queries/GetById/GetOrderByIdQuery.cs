using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;

namespace Infrastructures;

public sealed record GetOrderByIdQuery(Guid Id) : IRequest<GetOrderByIdResponse>;
public record GetOrderByIdResponse(Guid Id, double TotalPrice, DateTime CreationDate, string OrderStatus, string Address, List<GetOrderDetailsResponse> OrderDetails);
public record GetOrderDetailsResponse(Guid Id, Guid ProductItemId, int Quantity, double Price, string OrderItemStatus, GetProductItemResponse ProductItem);
public record GetProductItemResponse(Guid Id, string SKU, double OriginalPrice, double DiscountedPrice, int Stock, bool IsActive, List<GetProductItemsImagesResponse> ProductImages);
public class GetOrderByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync(
            predicate: x => x.Id == request.Id,
            include: source => source
                .Include(x => x.OrderDetails)
                    .ThenInclude(od => od.ProductItem)
                        .ThenInclude(pi => pi.ProductImages)
                .Include(x => x.DependentUser)
                    .ThenInclude(x => x.Addresses)
        );
        var order = orders.FirstOrDefault();
        if (order == null)
            throw new AppExceptions("Order not found");

        return new GetOrderByIdResponse
        (
            Id: order.Id,
            TotalPrice: (double)order.TotalPrice,
            CreationDate: order.CreationDate.Value,
            OrderStatus: order.OrderStatus.ToString(),
            Address: order.DependentUser.Addresses.FirstOrDefault()?.StreetAddress ?? "",
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
                    SKU: orderDetail.ProductItem.SKU,
                    OriginalPrice: (double)orderDetail.ProductItem.OriginalPrice,
                    DiscountedPrice: (double)orderDetail.ProductItem.DiscountedPrice,
                    Stock: orderDetail.ProductItem.Stock.Quantity,
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

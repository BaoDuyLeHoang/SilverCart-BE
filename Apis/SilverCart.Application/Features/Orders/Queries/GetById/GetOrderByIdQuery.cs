using Infrastructures.Commons.Exceptions;
using Infrastructures.Features.Products.Queries.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;

namespace Infrastructures;

public sealed record GetOrderByIdQuery(Guid Id) : IRequest<GetOrderByIdResponse>;
public record GetOrderByIdResponse(Guid Id, double TotalPrice, DateTime CreatedDate, List<GetStoreOrders> StoreOrders, string OrderStatus, string Address);
public record GetStoreOrders(Guid StoreId, Guid Id, DateTime CreatedDate, string StoreOrderStatus, string ShippingStatus, List<GetStoreProductItemOrder> StoreProductItemOrders);
public record GetStoreProductItemOrder(
    Guid Id,
    Guid StoreProductItemId,
    int Quantity,
    double Price,
    string ProductName,
    string VariantName,
    string StoreProductItemOrderStatus,
    List<GetProductItemsImagesResponse> ProductImages);

public class GetOrderByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync(
            predicate: x => x.Id == request.Id,
            include: source => source
                .Include(x => x.StoreOrders)
                    .ThenInclude(so => so.StoreProductItemsOrders)
                        .ThenInclude(spio => spio.StoreProductItem)
                            .ThenInclude(spi => spi.ProductItem)
                                .ThenInclude(pi => pi.ProductImages)
                .Include(x => x.StoreOrders)
                    .ThenInclude(so => so.StoreProductItemsOrders)
                        .ThenInclude(spio => spio.StoreProductItem)
                            .ThenInclude(spi => spi.ProductItem)
                                .ThenInclude(v => v.Variant)
                                    .ThenInclude(p => p.Product)
                .Include(x => x.Customer)
                    .ThenInclude(x => x.Addresses)
        );
        var order = orders.FirstOrDefault();
        if (order == null)
            throw new AppExceptions("Order not found");

        return new GetOrderByIdResponse
        (
            Id: order.Id,
            TotalPrice: order.TotalPrice,
            CreatedDate: order.CreationDate.Value,
            StoreOrders: order.StoreOrders.Select(storeOrder => new GetStoreOrders
            (
                StoreId: storeOrder.StoreId,
                Id: storeOrder.Id,
                CreatedDate: storeOrder.CreationDate.Value,
                ShippingStatus: storeOrder.ShippingStatus.ToString(),
                StoreOrderStatus: storeOrder.Status.ToString(),
                StoreProductItemOrders: storeOrder.StoreProductItemsOrders.Select(spio => new GetStoreProductItemOrder
                (
                    Id: spio.Id,
                    StoreProductItemId: spio.StoreProductItemId,
                    Quantity: spio.Quantity,
                    Price: spio.Price,
                    ProductName: spio.StoreProductItem.ProductItem.Variant.Product.Name,
                    VariantName: spio.StoreProductItem.ProductItem.Variant.VariantName,
                    StoreProductItemOrderStatus: spio.Status.ToString(),
                    ProductImages: spio.StoreProductItem.ProductItem.ProductImages.Select(img => new GetProductItemsImagesResponse
                    (
                        Id: img.Id,
                        ImagePath: img.ImagePath,
                        ImageName: img.ImageName
                    )).ToList()
                )).ToList()
            )).ToList(),
            OrderStatus: order.OrderStatus.ToString(),
            Address: order.Customer.Addresses.FirstOrDefault()?.StreetAddress ?? ""
        );
    }
}

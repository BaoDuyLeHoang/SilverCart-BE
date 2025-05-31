using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures;

public sealed record GetOrderByIdQuery(Guid Id) : IRequest<GetOrderByIdResponse>;
public record GetOrderByIdResponse(Guid Id, double TotalPrice, DateTime? CreatedDate, List<GetOrderItemsByIdResponse> OrderItems, string OrderStatus, string Address);
public record GetOrderItemsByIdResponse(Guid Id, List<GetStoreProductItemsByIdResponse> StoreProductItems, int Quantity, double Price, string OrderItemsStatus);
public record GetStoreProductItemsByIdResponse(Guid Id, string StoreName, string ProductName, string VariantName, List<GetProductItemsImagesResponse> ProductImages);
public record GetProductItemsImagesResponse(Guid Id, string ImagePath, string ImageName);
public class GetOrderByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResponse>
{
    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var orders = await unitOfWork.OrderRepository.GetAllAsync(
            predicate: x => x.Id == request.Id,
            include: x => x.Include(x => x.OrderItems)
                                .ThenInclude(x => x.StoreProductItem)
                                    .ThenInclude(x => x.ProductItem)
                                        .ThenInclude(x => x.ProductImages)
                            .Include(x => x.OrderItems)
                                .ThenInclude(x => x.StoreProductItem)
                                    .ThenInclude(x => x.Store)
                            .Include(x => x.OrderItems)
                                .ThenInclude(x => x.StoreProductItem)
                                    .ThenInclude(x => x.ProductItem)
                                        .ThenInclude(x => x.Variant)
                                            .ThenInclude(x => x.Product)
                            .Include(x => x.Customer)
                                .ThenInclude(x => x.Addresses)
        );
        var order = orders.FirstOrDefault();
        if (order == null) return null!;

        return new GetOrderByIdResponse(
            Id: order.Id,
            TotalPrice: order.TotalPrice,
            CreatedDate: order.CreationDate,
            OrderItems: order.OrderItems
                .Select(x => new GetOrderItemsByIdResponse(
                    x.Id,
                    new List<GetStoreProductItemsByIdResponse> {
                        new(
                            x.StoreProductItem.Id,
                            x.StoreProductItem.Store.Name,
                            x.StoreProductItem.ProductItem.Variant.Product.Name,
                            x.StoreProductItem.ProductItem.Variant.VariantName,
                            x.StoreProductItem.ProductItem.ProductImages
                                .Select(z => new GetProductItemsImagesResponse(z.Id, z.ImagePath, z.ImageName))
                                .ToList()
                        )
                    },
                    x.Quantity,
                    x.Price,
                    x.Status.ToString()))
                .ToList(),
            OrderStatus: order.OrderStatus.ToString(),
            Address: order.Customer.Addresses.FirstOrDefault()?.StreetAddress ?? ""
        );
    }
}

using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures;

public sealed record GetAllOrdersQuery(PagingRequest? PagingRequest, Guid? Id, Guid? CustomerId, OrderStatusEnums? OrderStatus) : IRequest<PagedResult<GetAllOrdersResponse>>;
public record GetAllOrdersResponse(Guid Id, double TotalPrice, DateTime? CreatedDate, List<GetAllStoreOrders> StoreOrders, string OrderStatus, string Address);
public record GetAllStoreOrders(Guid StoreId, Guid Id, DateTime CreatedDate, string StoreOrderStatus, string ShippingStatus, List<GetAllStoreProductItemOrder> StoreProductItemOrders);
public record GetAllStoreProductItemOrder(Guid Id, Guid StoreProductItemId, int Quantity, double Price, string ProductName, string VariantName, string Status, List<GetProductItemsImagesResponse> ProductImages);
public record GetProductItemsImagesResponse(Guid Id, string ImagePath, string ImageName);
public class GetAllOrdersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllOrdersQuery, PagedResult<GetAllOrdersResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<PagedResult<GetAllOrdersResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync(
           predicate: _ => true,
           include: x => x.Include(x => x.StoreOrders)
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

        var filteredEntity = new Order
        {
            Id = request.Id.HasValue ? request.Id.Value : Guid.Empty,
            CustomerId = request.CustomerId.HasValue ? request.CustomerId.Value : Guid.Empty,
            OrderStatus = request.OrderStatus.HasValue ? request.OrderStatus.Value : OrderStatusEnums.All,
        };

        var filteredOrders = orders.AsQueryable().CustomFilterV1(filteredEntity);

        var mappedOrders = filteredOrders.Select(order => new GetAllOrdersResponse(
           order.Id,
           order.TotalPrice,
           order.CreationDate,
           order.StoreOrders.Select(storeOrder => new GetAllStoreOrders(
                storeOrder.StoreId,
                storeOrder.Id,
                storeOrder.CreationDate.Value,
                storeOrder.Status.ToString(),
                storeOrder.ShippingStatus.ToString(),
                storeOrder.StoreProductItemsOrders.Select(
                    spio => new GetAllStoreProductItemOrder(
                        spio.Id,
                        spio.StoreProductItemId,
                        spio.Quantity,
                        spio.Price,
                        spio.StoreProductItem.ProductItem.Variant.Product.Name,
                        spio.StoreProductItem.ProductItem.Variant.VariantName,
                        spio.Status.ToString(),
                        spio.StoreProductItem.ProductItem.ProductImages.Select(
                            img => new GetProductItemsImagesResponse(
                                img.Id,
                                img.ImagePath,
                                img.ImageName
                            )
                        ).ToList()
                    )
                ).ToList()
            )).ToList(),
            order.OrderStatus.ToString(),
            order.Customer.Addresses.FirstOrDefault().StreetAddress ?? ""
        ));

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResult = PaginationHelper<GetAllOrdersResponse>.Sorting(sortType, mappedOrders, sortField);
        var result = PaginationHelper<GetAllOrdersResponse>.Paging(sortedResult, page, pageSize);

        return result;
    }

}

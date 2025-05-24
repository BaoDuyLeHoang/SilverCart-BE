using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures;

public sealed record GetAllOrdersQuery(PagingRequest? PagingRequest, Guid? Id, Guid? CustomerId, OrderStatusEnums? OrderStatus) : IRequest<PagedResult<GetAllOrdersResponse>>;
public record GetAllOrdersResponse(Guid Id, double TotalPrice, DateTime? CreatedDate, List<GetAllOrdersResponseItem> OrderItems);
public record GetAllOrdersResponseItem(Guid Id, Guid StoreProductItemId, int Quantity, double Price);
public class GetAllOrdersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllOrdersQuery, PagedResult<GetAllOrdersResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<PagedResult<GetAllOrdersResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync(
            predicate: _ => true,
            include: x => x.Include(x => x.OrderItems));

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
            order.OrderItems.Select(
                item => new GetAllOrdersResponseItem(
                    item.Id,
                    item.StoreProductItemId,
                    item.Quantity,
                    item.Price)
                ).ToList()
            )
        ).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResult = PaginationHelper<GetAllOrdersResponse>.Sorting(sortType, mappedOrders, sortField);
        var result = PaginationHelper<GetAllOrdersResponse>.Paging(sortedResult, page, pageSize);

        return result;
    }

}

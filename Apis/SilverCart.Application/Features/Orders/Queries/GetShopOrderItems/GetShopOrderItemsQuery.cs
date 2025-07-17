using Infrastructures.Commons.Exceptions;
using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Queries.GetShopOrderItems
{
    public sealed record GetShopOrderItemsCommand(Guid StoreId, Guid? OrderId, PagingRequest? PagingRequest, DateOnly? FromDate, DateOnly? ToDate, OrderStatusEnum? OrderStatus) : IRequest<PagedResult<GetShopOrderResponse>>;
    public record GetShopOrderResponse(Guid Id, Guid OrderId, DateTime CreationDate, string OrderStatus, List<GetShopOrderDetailsResponse> OrderDetails);
    public record GetShopOrderDetailsResponse(Guid Id, Guid ProductItemId, int Quantity, double Price, string OrderItemStatus, GetShopProductItemResponse ProductItem);
    public record GetShopProductItemResponse(Guid Id, string SKU, double OriginalPrice, double DiscountedPrice, int Stock, bool IsActive, List<GetProductItemsImagesResponse> ProductImages);
    public record GetProductItemsImagesResponse(Guid Id, string ImagePath, string ImageName);

    public class GetShopOrderItemsQuery(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetShopOrderItemsCommand, PagedResult<GetShopOrderResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;

        public async Task<PagedResult<GetShopOrderResponse>> Handle(GetShopOrderItemsCommand request, CancellationToken cancellationToken)
        {
            // Get orders that have order details with product items from the specified store
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(
                predicate: x => x.OrderDetails.Any(od => od.ProductItem.StoreId == request.StoreId),
                include: x => x.Include(x => x.OrderDetails.Where(od => od.ProductItem.StoreId == request.StoreId))
                                .ThenInclude(od => od.ProductItem)
                                    .ThenInclude(pi => pi.ProductImages)
            );

            var filteredOrders = orders.AsQueryable();

            if (request.OrderId.HasValue)
            {
                filteredOrders = filteredOrders.Where(x => x.Id == request.OrderId.Value);
            }

            if (request.FromDate.HasValue)
            {
                filteredOrders = filteredOrders.Where(x => x.CreationDate >= request.FromDate.Value.ToDateTime(TimeOnly.MinValue));
            }

            if (request.ToDate.HasValue)
            {
                filteredOrders = filteredOrders.Where(x => x.CreationDate <= request.ToDate.Value.ToDateTime(TimeOnly.MaxValue));
            }

            if (request.OrderStatus.HasValue)
            {
                filteredOrders = filteredOrders.Where(x => x.OrderStatus == request.OrderStatus.Value);
            }

            var mappedOrders = filteredOrders.Select(order => new GetShopOrderResponse(
                order.Id,
                order.Id, // OrderId is the same as Id in this simplified structure
                order.CreationDate.Value,
                order.OrderStatus.ToString(),
                order.OrderDetails.Where(od => od.ProductItem.StoreId == request.StoreId)
                    .Select(orderDetail => new GetShopOrderDetailsResponse(
                        orderDetail.Id,
                        orderDetail.ProductItemId,
                        orderDetail.Quantity,
                        (double)orderDetail.Price,
                        orderDetail.OrderItemStatus.ToString(),
                        new GetShopProductItemResponse(
                            orderDetail.ProductItem.Id,
                            orderDetail.ProductItem.SKU,
                            (double)orderDetail.ProductItem.OriginalPrice,
                            (double)orderDetail.ProductItem.DiscountedPrice,
                            orderDetail.ProductItem.Stock.Quantity,
                            orderDetail.ProductItem.IsActive,
                            orderDetail.ProductItem.ProductImages.Select(
                                img => new GetProductItemsImagesResponse(
                                    img.Id,
                                    img.ImagePath,
                                    img.ImageName
                                )
                            ).ToList()
                        )
                    )).ToList()
            ));

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
            var sortedResult = PaginationHelper<GetShopOrderResponse>.Sorting(sortType, mappedOrders, sortField);
            var result = PaginationHelper<GetShopOrderResponse>.Paging(sortedResult, page, pageSize);
            return result;
        }
    }
}

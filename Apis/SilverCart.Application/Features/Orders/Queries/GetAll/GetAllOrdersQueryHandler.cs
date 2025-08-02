using Core.Interfaces;
using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;
using SilverCart.Application.Interfaces;
namespace Infrastructures
{
    public sealed record GetAllOrdersQuery(PagingRequest? PagingRequest, string? keyword, Guid? CustomerId, OrderStatusEnum? OrderStatus) : IRequest<PagedResult<GetAllOrdersResponse>>;
    public record GetAllOrdersResponse(Guid Id, double TotalPrice, DateTime? CreationDate, string OrderStatus, string ToAddress, string? FromAddress, List<GetAllOrderDetailsResponse> OrderDetails);
    public record GetAllOrderDetailsResponse(Guid Id, Guid ProductItemId, int Quantity, double Price, string OrderItemStatus, GetAllProductItemResponse ProductItem);
    public record GetAllProductItemResponse(Guid Id, string ProductName, double OriginalPrice, double DiscountedPrice, int Stock, bool IsActive, List<GetProductItemsImagesResponse> ProductImages);
    public record GetProductItemsImagesResponse(Guid Id, string ImagePath, string ImageName);
    public class GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IRedisService redisService, IClaimsService claimsService) : IRequestHandler<GetAllOrdersQuery, PagedResult<GetAllOrdersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        public async Task<PagedResult<GetAllOrdersResponse>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {

            var cacheKey = JsonConvert.SerializeObject(request);
            var cachedOrders = await redisService.GetAsync<PagedResult<GetAllOrdersResponse>>(cacheKey);
            if (cachedOrders != null)
            {
                return cachedOrders;
            }

            var orders = await _unitOfWork.OrderRepository.GetAllAsync(
               predicate: _ => true,
               include: x => x.Include(x => x.OrderDetails)
                            .ThenInclude(od => od.ProductItem)
                                .ThenInclude(pi => pi.ProductImages)
                    .Include(x => x.OrderedUser)
                        .ThenInclude(x => x.Addresses)
               );

            var filteredEntity = new Order
            {
                Id = Guid.Empty,
                OrderedUserId = request.CustomerId.HasValue ? request.CustomerId.Value : Guid.Empty,
                OrderStatus = request.OrderStatus.HasValue ? request.OrderStatus.Value : OrderStatusEnum.All,
            };

            var filteredOrders = orders.AsQueryable().CustomFilterV1(filteredEntity, request.keyword);

            var currentUserRole = _claimsService.CurrentRole;
            var isCustomerRole = currentUserRole == RoleEnum.Guardian || currentUserRole == RoleEnum.DependentUser;
            // only Staff Admins can view From Address
            var mappedOrders = filteredOrders.Select(order => new GetAllOrdersResponse(
               order.Id,
               (double)order.TotalPrice,
               order.CreationDate,
               order.OrderStatus.ToString(),
               order.ToAddress,
               isCustomerRole ? null : order.FromAddress,
               order.OrderDetails.Select(orderDetail => new GetAllOrderDetailsResponse(
                    orderDetail.Id,
                    orderDetail.ProductItemId,
                    orderDetail.Quantity,
                    (double)orderDetail.Price,
                    orderDetail.OrderItemStatus.ToString(),
                    new GetAllProductItemResponse(
                        orderDetail.ProductItem.Id,
                        orderDetail.ProductItem.ProductName,
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
            )).ToList();

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            var sortedResult = PaginationHelper<GetAllOrdersResponse>.Sorting(sortType, mappedOrders, sortField);
            var result = PaginationHelper<GetAllOrdersResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}

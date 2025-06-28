using Infrastructures.Commons.Exceptions;
using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Orders.Queries.GetShopOrderItems
{
    public sealed record GetShopOrderItemsCommand(Guid StoreId, Guid? StoreOrderId, PagingRequest? PagingRequest, DateOnly? FromDate, DateOnly? ToDate, StoreOrderStatus? StoreOrderStatus, StoreOrderShippingGhnStatusEnum? ShippingStatus) : IRequest<PagedResult<GetShoreOrderResponse>>;
    public record GetShoreOrderResponse(Guid Id, Guid OrderId, DateTime CreatedDate, string StoreOrderStatus, string ShippingStatus, List<GetStoreProductItemOrder> StoreProductItemOrders);
    public class GetShopOrderItemsQuery(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetShopOrderItemsCommand, PagedResult<GetShoreOrderResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        public async Task<PagedResult<GetShoreOrderResponse>> Handle(GetShopOrderItemsCommand request, CancellationToken cancellationToken)
        {
            // var currentStoreUserId = _claimsService.CurrentUserId;
            // var isCurrentStoreUser = await _unitOfWork.StoreUserRepository.GetByIdAsync(currentStoreUserId);
            // if (isCurrentStoreUser == null)
            // {
            //     throw new AppExceptions("Store user not found");
            // }
            var storeOrders = await _unitOfWork.StoreOrderRepository.GetAllAsync(
                predicate: x => x.StoreId == request.StoreId,
                include: x => x.Include(x => x.StoreProductItemsOrders)
                                    .ThenInclude(x => x.StoreProductItem)
                                        .ThenInclude(x => x.ProductItem)
                                            .ThenInclude(x => x.ProductImages)
                                .Include(x => x.StoreProductItemsOrders)
                                    .ThenInclude(x => x.StoreProductItem)
                                        .ThenInclude(x => x.ProductItem)
                                            .ThenInclude(x => x.Variant)
                                                .ThenInclude(x => x.Product)
            );
            var filterEntity = new StoreOrder
            {
                Id = request.StoreOrderId.HasValue ? request.StoreOrderId.Value : Guid.Empty,
                StoreId = request.StoreId,
                Status = request.StoreOrderStatus.HasValue ? request.StoreOrderStatus.Value : StoreOrderStatus.All,
                ShippingStatus = request.ShippingStatus.HasValue ? request.ShippingStatus.Value : StoreOrderShippingGhnStatusEnum.All,
            };

            var filteredOrders = storeOrders.AsQueryable().CustomFilterV1(filterEntity);
            if (request.FromDate.HasValue)
            {
                filteredOrders = filteredOrders.Where(x => x.CreationDate >= request.FromDate.Value.ToDateTime(TimeOnly.MinValue));
            }
            if (request.ToDate.HasValue)
            {
                filteredOrders = filteredOrders.Where(x => x.CreationDate <= request.ToDate.Value.ToDateTime(TimeOnly.MaxValue));
            }
            if (request.StoreOrderStatus.HasValue)
            {
                filteredOrders = filteredOrders.Where(x => x.Status == request.StoreOrderStatus.Value);
            }
            if (request.ShippingStatus.HasValue)
            {
                filteredOrders = filteredOrders.Where(x => x.ShippingStatus == request.ShippingStatus);
            }
            var mappedOrders = filteredOrders.Select(order => new GetShoreOrderResponse(
                order.Id,
                order.OrderId,
                order.CreationDate.Value,
                order.Status.ToString(),
                order.ShippingStatus.ToString(),
                order.StoreProductItemsOrders.Select(x => new GetStoreProductItemOrder(
                    x.Id,
                    x.StoreProductItemId,
                    x.Quantity,
                    x.Price,
                    x.StoreProductItem.ProductItem.Variant.Product.Name,
                    x.StoreProductItem.ProductItem.Variant.VariantName,
                    x.Status.ToString(),
                    x.StoreProductItem.ProductItem.ProductImages.Select(
                        x => new GetProductItemsImagesResponse(
                            x.Id,
                            x.ImagePath,
                            x.ImageName
                        )
                    ).ToList()
                )
                ).ToList()
            ));

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
            var sortedResult = PaginationHelper<GetShoreOrderResponse>.Sorting(sortType, mappedOrders, sortField);
            var result = PaginationHelper<GetShoreOrderResponse>.Paging(sortedResult, page, pageSize);
            return result;
        }
    }
}

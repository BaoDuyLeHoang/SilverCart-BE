using Infrastructures.Commons.Exceptions;
using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Orders.Queries.GetShopOrderItems
{
    public sealed record GetShopOrderItemsCommand(Guid? OrderItemsId, PagingRequest? PagingRequest, DateOnly? FromDate, DateOnly? ToDate) : IRequest<PagedResult<GetShopOrderItemsResponse>>;
    public record GetShopOrderItemsResponse(Guid OrderItemsId, string OrderItemsName, int Quantity, double Price, DateTime CreatedAt, string Address, string CustomerName, string CustomerPhone);
    public class GetShopOrderItemsQuery(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<GetShopOrderItemsCommand, PagedResult<GetShopOrderItemsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        public async Task<PagedResult<GetShopOrderItemsResponse>> Handle(GetShopOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var currentShopUserId = _claimsService.CurrentUserId;
            var currentShopUser = await _unitOfWork.StoreUserRepository.GetByIdAsync(currentShopUserId);
            if (currentShopUser == null)
                throw new AppExceptions("Shop user not found");

            var currentShop = await _unitOfWork.StoreRepository.GetByIdAsync(currentShopUser.StoreId.Value);
            if (currentShop == null)
                throw new AppExceptions("Shop not found");

            var orderItems = await _unitOfWork.OrderItemRepository.GetAllAsync(
                predicate: x => x.Id == request.OrderItemsId && x.StoreProductItem.StoreId == currentShop.Id,
                include: x => x.Include(x => x.Order)
                                    .ThenInclude(x => x.Customer)
                                        .ThenInclude(x => x.Addresses)
                                .Include(x => x.StoreProductItem)
                                    .ThenInclude(x => x.ProductItem)
                                        .ThenInclude(x => x.ProductImages)
                                .Include(x => x.StoreProductItem)
                                    .ThenInclude(x => x.ProductItem)
                                        .ThenInclude(x => x.Variant)
                                            .ThenInclude(x => x.Product)
            );

            if (orderItems == null)
                throw new AppExceptions("Order items not found");

            var filteredEntity = new OrderItem
            {
                Id = request.OrderItemsId.HasValue ? request.OrderItemsId.Value : Guid.Empty,
            };

            var filteredOrderItems = orderItems.AsQueryable().CustomFilterV1(filteredEntity);
            if (request.FromDate.HasValue && request.ToDate.HasValue)
            {
                filteredOrderItems = filteredOrderItems.Where(x => x.Order.CreationDate >= request.FromDate.Value.ToDateTime(TimeOnly.MinValue) && x.Order.CreationDate <= request.ToDate.Value.ToDateTime(TimeOnly.MaxValue));
            }
            var mappedOrderItems = filteredOrderItems.Select(orderItem => new GetShopOrderItemsResponse(
                orderItem.Id,
                orderItem.StoreProductItem.ProductItem.Variant.Product.Name,
                orderItem.Quantity,
                orderItem.Price,
                orderItem.Order.CreationDate.Value,
                orderItem.Order.Customer.Addresses.FirstOrDefault().StreetAddress ?? "",
                orderItem.Order.Customer.FullName ?? "",
                orderItem.Order.Customer.PhoneNumber ?? ""
            ));

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
            var sortedResult = PaginationHelper<GetShopOrderItemsResponse>.Sorting(sortType, mappedOrderItems, sortField);
            var result = PaginationHelper<GetShopOrderItemsResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}

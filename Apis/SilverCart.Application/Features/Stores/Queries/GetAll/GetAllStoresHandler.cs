using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Stores.Queries.GetAll
{
    public class GetAllStoresHandler : IRequestHandler<GetAllStoresQuery, PagedResult<GetAllStoresResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllStoresHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<GetAllStoresResponse>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            var storesQuery = await _unitOfWork.StoreRepository.GetAllAsync(
                predicate: s => !s.IsDeleted,
                include: source => source.Include(s => s.StoreAddress)
            );

            // Apply filters using CustomFilterV1
            var filteredEntity = new Store
            {
                Id = request.Id.HasValue ? request.Id.Value : Guid.Empty,
                Name = !string.IsNullOrWhiteSpace(request.StoreName) ? request.StoreName : string.Empty,
                IsActive = request.IsActive.HasValue && request.IsActive.Value
            };

            var filteredStores = storesQuery.AsQueryable().CustomFilterV1(filteredEntity);

            // Map to response
            var storesResponse = filteredStores.Select(store => new GetAllStoresResponse
            {
                Id = store.Id,
                StoreName = store.Name,
                Information = store.Infomation,
                AvatarPath = store.AvatarPath,
                AdditionalInfo = store.AdditionalInfo,
                IsActive = store.IsActive,
                IsGhnSynced = store.IsGhnSynced,
                GhnShopId = store.GhnShopId,
                CreatedDate = store.CreationDate,
                StoreAddress = store.StoreAddress != null ? new StoreAddressResponse
                {
                    Id = store.StoreAddress.Id,
                    StreetAddress = store.StoreAddress.StreetAddress,
                    WardCode = store.StoreAddress.WardCode,
                    DistrictId = store.StoreAddress.DistrictId,
                    WardName = store.StoreAddress.WardName,
                    DistrictName = store.StoreAddress.DistrictName,
                    ProvinceName = store.StoreAddress.ProvinceName
                } : null
            }).ToList();

            // Apply pagination
            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            var sortedResult = PaginationHelper<GetAllStoresResponse>.Sorting(sortType, storesResponse, sortField);
            var result = PaginationHelper<GetAllStoresResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}
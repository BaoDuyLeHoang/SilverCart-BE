using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Admin.Queries.Promotion;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;

namespace Infrastructures.Users.Queries.GetPromotionDetailHandler
{
    public class GetPromotionDetailHandler : IRequestHandler<GetPromotionDetailQuery, PagedResult<GetPromotionDetailResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPromotionDetailHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<GetPromotionDetailResponse>> Handle(GetPromotionDetailQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.PromotionRepository.GetAllAsync(
                predicate: x => !x.IsDeleted
            );
            //Filtering
            var filteredEntity = new Promotion
            {
                Id = request.Id.HasValue ? request.Id.Value : Guid.Empty,
                Name = !string.IsNullOrEmpty(request.Name) ? request.Name : string.Empty,
                StartDate = request.StartDate.HasValue ? request.StartDate.Value : DateTime.MinValue,
                EndDate = request.EndDate.HasValue ? request.EndDate.Value : DateTime.MaxValue,
            };

            var filteredReports = query.AsQueryable().CustomFilterV1(filteredEntity);


            //Mapping
            var mappedPromotions = await query
                .Select(promo => new GetPromotionDetailResponse(
                    promo.Id,
                    promo.Name,
                    promo.Description,
                    promo.StartDate,
                    promo.EndDate,
                    promo.Discount,
                    promo.DiscountType.ToString(),
                    promo.IsActive,
                    promo.MinimumQuantity,
                    promo.MaximumQuantity,
                    promo.MinimumPrice,
                    promo.MaximumPrice,
                    promo.CreationDate,
                    promo.CreatedById
                )).ToListAsync(cancellationToken);

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
            var sortedResult = PaginationHelper<GetPromotionDetailResponse>.Sorting(sortType, mappedPromotions, sortField);
            var result = PaginationHelper<GetPromotionDetailResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}

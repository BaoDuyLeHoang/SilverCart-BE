using Infrastructures.Commons.Paginations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Queries.GetAll
{
    public sealed record GetAllPromotionsQuery(PagingRequest? PagingRequest,
        string? Keyword,
        bool? IsActive = null
    ) : IRequest<PagedResult<GetAllPromotionsResponse>>;
    public record GetAllPromotionsResponse(Guid? Id, string Name, string Description, DateTime StartDate, DateTime EndDate, decimal DiscountAmount, string DiscountType, bool IsActive, int MinimumQuantity, int MaximumQuanitity, decimal MinimumPrice, decimal MaximumPrice);
    public class GetAllPromotionsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllPromotionsQuery, PagedResult<GetAllPromotionsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<PagedResult<GetAllPromotionsResponse>> Handle(GetAllPromotionsQuery request, CancellationToken cancellationToken)
        {
            var promotions = await _unitOfWork.PromotionRepository.GetAllAsync(
                predicate: p => string.IsNullOrEmpty(request.Keyword) || p.Name.Contains(request.Keyword) || p.DiscountType.Equals(request.Keyword) || p.IsActive == request.IsActive
            );

            var mappedPromotions = promotions.Select(p => new GetAllPromotionsResponse(
                p.Id,
                p.Name,
                p.Description,
                p.StartDate,
                p.EndDate,
                p.Discount,
                p.DiscountType.ToString(),
                p.IsActive,
                p.MinimumQuantity,
                p.MaximumQuantity,
                p.MinimumPrice,
                p.MaximumPrice
            )).ToList();

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            var sortedResult = PaginationHelper<GetAllPromotionsResponse>.Sorting(sortType, mappedPromotions, "StartDate");
            var result = PaginationHelper<GetAllPromotionsResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}

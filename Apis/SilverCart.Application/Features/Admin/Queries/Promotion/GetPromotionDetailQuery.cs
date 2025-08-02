using Infrastructures.Commons.Paginations;
using MediatR;

namespace Infrastructures.Features.Admin.Queries.Promotion
{
    public sealed record GetPromotionDetailQuery(PagingRequest? PagingRequest, Guid? Id, string? Name, DateTime? StartDate, DateTime? EndDate) : IRequest<PagedResult<GetPromotionDetailResponse>>;

    public record GetPromotionDetailResponse(
        Guid Id,
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        decimal Discount,
        string DiscountType,
        bool IsActive,
        int MinimumQuantity,
        int MaximumQuantity,
        decimal MinimumPrice,
        decimal MaximumPrice,
        DateTime? CreationDate,
        Guid? CreatedById);
}

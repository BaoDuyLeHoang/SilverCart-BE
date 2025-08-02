using Infrastructures.Commons.Paginations;
using MediatR;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Categories.Queries.GetAll
{
    public sealed record GetAllCategoriesQuery(PagingRequest? PagingRequest, Guid? Id, string? CategoryName, CategoryStatusEnum? Status, Guid? ParentCategoryId) : IRequest<PagedResult<GetAllCategoryResponse>>;

    public record GetAllCategoryResponse(
        Guid Id,
        string Name,
        string Description,
        string Status,
        Guid? ParentCategoryId,
        string? ParentCategoryName,
        DateTime? CreationDate,
        int ProductCount);
}
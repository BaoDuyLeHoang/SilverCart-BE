using Infrastructures.Features.Categories.Queries.GetAll;
using MediatR;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Categories.Queries.GetById
{
    public sealed record GetCategoryByIdQuery(Guid Id) : IRequest<GetAllCategoryResponse>;
}
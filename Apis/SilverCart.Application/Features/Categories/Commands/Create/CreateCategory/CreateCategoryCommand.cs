using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Categories.Commands.Create.CreateCategory
{
    public sealed record CreateCategoryCommand(Guid? ParentCategoryId, string Name, string Description, CategoryStatusEnum Status) : IRequest<Guid>;
}
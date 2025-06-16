using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Categories.Commands.Update.UpdateCategory
{
    public sealed record UpdateCategoryCommand(Guid Id, Guid? ParentCategoryId, string Name, string Description, CategoryStatusEnum Status) : IRequest<Guid>;
}
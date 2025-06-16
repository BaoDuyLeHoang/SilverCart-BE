using MediatR;

namespace Infrastructures.Features.Categories.Commands.Delete.DeleteCategory
{
    public sealed record DeleteCategoryCommand(Guid Id) : IRequest<Guid>;
}
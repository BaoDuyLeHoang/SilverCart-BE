using FluentValidation;
using Infrastructures.Features.Categories.Commands.Delete.DeleteCategory;

namespace SilverCart.Application.Features.Categories.Commands.Delete.DeleteCategory
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID danh mục không được để trống");
        }
    }
}
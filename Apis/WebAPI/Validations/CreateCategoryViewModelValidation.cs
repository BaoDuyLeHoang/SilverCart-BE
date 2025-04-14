using Application.ViewModels.CategorysViewModels;
using FluentValidation;

namespace WebAPI.Validations
{
    public class CreateCategoryViewModelValidation : AbstractValidator<CreateCategoryViewModel>
    {
        public CreateCategoryViewModelValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}

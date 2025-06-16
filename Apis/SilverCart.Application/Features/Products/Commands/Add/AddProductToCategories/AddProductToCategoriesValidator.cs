using FluentValidation;
using Infrastructures.Features.Products.Commands.Add.AddProductToCategories;

namespace SilverCart.Application.Features.Products.Commands.Add.AddProductToCategories
{
    public class AddProductToCategoriesValidator : AbstractValidator<AddProductToCategoriesCommand>
    {
        public AddProductToCategoriesValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ID sản phẩm không được để trống");

            RuleFor(x => x.CategoryIds)
                .NotEmpty().WithMessage("Danh sách ID danh mục không được để trống");

            RuleForEach(x => x.CategoryIds)
                .NotEmpty().WithMessage("ID danh mục không được để trống");
        }
    }
}
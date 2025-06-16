using FluentValidation;
using Infrastructures.Features.Products.Commands.Update.UpdateProductVariant;

namespace SilverCart.Application.Features.Products.Commands.Update.UpdateProductVariant
{
    public class UpdateProductVariantValidator : AbstractValidator<UpdateProductVariantCommand>
    {
        public UpdateProductVariantValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ID sản phẩm không được để trống");

            RuleFor(x => x.VariantId)
                .NotEmpty().WithMessage("ID biến thể không được để trống");

            RuleFor(x => x.ProductVariant).ChildRules(variant =>
            {
                variant.RuleFor(v => v.VariantName)
                    .NotEmpty().WithMessage("Tên biến thể không được để trống")
                    .MaximumLength(100).WithMessage("Tên biến thể không được vượt quá 100 ký tự");

                variant.RuleFor(v => v.Price)
                    .GreaterThanOrEqualTo(0).WithMessage("Giá biến thể phải lớn hơn hoặc bằng 0");
            });
        }
    }
}
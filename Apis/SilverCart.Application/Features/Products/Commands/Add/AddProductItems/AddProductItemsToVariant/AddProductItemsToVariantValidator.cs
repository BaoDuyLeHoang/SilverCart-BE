using FluentValidation;
using Infrastructures.Features.Products.Commands.Add.AddProductItems.AddProductItemsToVariant;

namespace SilverCart.Application.Features.Products.Commands.Add.AddProductItems.AddProductItemsToVariant
{
    public class AddProductItemsToVariantValidator : AbstractValidator<AddProductItemsToVariantCommand>
    {
        public AddProductItemsToVariantValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ID sản phẩm không được để trống");

            RuleFor(x => x.VariantId)
                .NotEmpty().WithMessage("ID biến thể không được để trống");

            RuleFor(x => x.ProductItems).ChildRules(item =>
            {
                item.RuleFor(i => i.Stock)
                    .GreaterThanOrEqualTo(0).WithMessage("Số lượng tồn kho phải lớn hơn hoặc bằng 0");

                item.RuleFor(i => i.OriginalPrice)
                    .GreaterThanOrEqualTo(0).WithMessage("Giá gốc phải lớn hơn hoặc bằng 0");

                item.RuleFor(i => i.DiscountedPrice)
                    .GreaterThanOrEqualTo(0).WithMessage("Giá khuyến mãi phải lớn hơn hoặc bằng 0")
                    .LessThanOrEqualTo(i => i.OriginalPrice).WithMessage("Giá khuyến mãi phải nhỏ hơn hoặc bằng giá gốc");
            });
        }
    }
}
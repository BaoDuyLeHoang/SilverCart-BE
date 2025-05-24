using FluentValidation;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;
using SilverCart.Domain.Enums;

namespace SilverCart.Application.Features.Products.Commands.Create.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên sản phẩm không được để trống")
                .MaximumLength(200).WithMessage("Tên sản phẩm không được vượt quá 200 ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Mô tả không được vượt quá 2000 ký tự");

            RuleFor(x => x.ProductType)
                .IsInEnum().WithMessage("Loại sản phẩm không hợp lệ")
                .NotEqual(ProductTypeEnum.All).WithMessage("Loại sản phẩm không thể là 'All'");

            When(x => x.CategoryIds != null && x.CategoryIds.Any(), () =>
            {
                RuleForEach(x => x.CategoryIds)
                    .NotEmpty().WithMessage("ID danh mục không được để trống");
            });

            When(x => x.ProductVariants != null && x.ProductVariants.Any(), () =>
            {
                RuleForEach(x => x.ProductVariants).ChildRules(variant =>
                {
                    variant.RuleFor(v => v.VariantName)
                        .NotEmpty().WithMessage("Tên biến thể không được để trống")
                        .MaximumLength(100).WithMessage("Tên biến thể không được vượt quá 100 ký tự");

                    variant.RuleFor(v => v.Price)
                        .GreaterThanOrEqualTo(0).WithMessage("Giá biến thể phải lớn hơn hoặc bằng 0");

                    variant.When(v => v.ProductItems != null && v.ProductItems.Any(), () =>
                    {
                        variant.RuleForEach(v => v.ProductItems).ChildRules(item =>
                        {
                            item.RuleFor(i => i.Stock)
                                .GreaterThanOrEqualTo(0).WithMessage("Số lượng tồn kho phải lớn hơn hoặc bằng 0");

                            item.RuleFor(i => i.OriginalPrice)
                                .GreaterThanOrEqualTo(0).WithMessage("Giá gốc phải lớn hơn hoặc bằng 0");

                            item.RuleFor(i => i.DiscountedPrice)
                                .GreaterThanOrEqualTo(0).WithMessage("Giá khuyến mãi phải lớn hơn hoặc bằng 0")
                                .LessThanOrEqualTo(i => i.OriginalPrice).WithMessage("Giá khuyến mãi phải nhỏ hơn hoặc bằng giá gốc");

                            item.When(i => i.ProductImages != null && i.ProductImages.Any(), () =>
                            {
                                item.RuleForEach(i => i.ProductImages).ChildRules(image =>
                                {
                                    image.RuleFor(i => i.ImagePath)
                                        .NotEmpty().WithMessage("Đường dẫn hình ảnh không được để trống")
                                        .MaximumLength(500).WithMessage("Đường dẫn hình ảnh không được vượt quá 500 ký tự");

                                    image.RuleFor(i => i.ImageName)
                                        .NotEmpty().WithMessage("Tên hình ảnh không được để trống")
                                        .MaximumLength(100).WithMessage("Tên hình ảnh không được vượt quá 100 ký tự");
                                });
                            });
                        });
                    });
                });
            });
        }
    }
}
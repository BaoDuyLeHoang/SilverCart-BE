using FluentValidation;
using Infrastructures.Features.Products.Commands.Add.AddProductImages;

namespace SilverCart.Application.Features.Products.Commands.Add.AddProductImages
{
    public class AddProductImagesValidator : AbstractValidator<AddProductImagesCommand>
    {
        public AddProductImagesValidator()
        {
            RuleFor(x => x.ProductItemId)
                .NotEmpty().WithMessage("ID sản phẩm không được để trống");

            RuleFor(x => x.ProductImages)
                .NotEmpty().WithMessage("Danh sách hình ảnh không được để trống");

            RuleForEach(x => x.ProductImages).ChildRules(image =>
            {
                image.RuleFor(i => i.ImagePath)
                    .NotEmpty().WithMessage("Đường dẫn hình ảnh không được để trống")
                    .MaximumLength(500).WithMessage("Đường dẫn hình ảnh không được vượt quá 500 ký tự");

                image.RuleFor(i => i.ImageName)
                    .NotEmpty().WithMessage("Tên hình ảnh không được để trống")
                    .MaximumLength(100).WithMessage("Tên hình ảnh không được vượt quá 100 ký tự");
            });
        }
    }
}
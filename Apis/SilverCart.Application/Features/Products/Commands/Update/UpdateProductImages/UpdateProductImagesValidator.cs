using FluentValidation;
using Infrastructures.Features.Products.Commands.Update.UpdateProductImages;

namespace SilverCart.Application.Features.Products.Commands.Update.UpdateProductImages
{
    public class UpdateProductImagesValidator : AbstractValidator<UpdateProductImagesCommand>
    {
        public UpdateProductImagesValidator()
        {
            RuleFor(x => x.ProductItemId)
                .NotEmpty().WithMessage("ID sản phẩm không được để trống");

            RuleFor(x => x.ProductImages)
                .NotEmpty().WithMessage("Danh sách hình ảnh không được để trống");

            RuleForEach(x => x.ProductImages).ChildRules(image =>
            {
                image.RuleFor(i => i.Id)
                    .NotEmpty().WithMessage("ID hình ảnh không được để trống");

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
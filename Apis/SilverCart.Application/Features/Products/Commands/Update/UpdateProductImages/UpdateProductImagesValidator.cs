using FluentValidation;

namespace Infrastructures.Features.Products.Commands.Update.UpdateProductImages
{
    public class UpdateProductImagesValidator : AbstractValidator<UpdateProductImagesCommand>
    {
        public UpdateProductImagesValidator()
        {
            RuleFor(x => x.ImageId)
                .NotEmpty().WithMessage("ID ảnh không được để trống");

            When(x => x.Image != null, () =>
            {
                RuleFor(x => x.Image)
                    .Must(x => x!.Length > 0).WithMessage("File ảnh không được rỗng")
                    .Must(x => x!.ContentType.StartsWith("image/")).WithMessage("File phải là ảnh");
            });

            RuleFor(x => x)
                .Must(x => x.ProductId.HasValue || x.ProductItemId.HasValue)
                .WithMessage("Phải chỉ định ProductId hoặc ProductItemId");

            RuleFor(x => x.Order)
                .GreaterThanOrEqualTo(0).WithMessage("Order phải lớn hơn hoặc bằng 0");
        }
    }
}
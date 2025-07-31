using FluentValidation;
using System.Linq;

namespace Infrastructures.Features.Products.Commands.Add.AddProductImages
{
    public class AddProductImagesValidator : AbstractValidator<AddProductImagesCommand>
    {
        public AddProductImagesValidator()
        {
            RuleFor(x => x.Images)
                .NotEmpty().WithMessage("Danh sách ảnh không được để trống")
                .Must(x => x.Count <= 10).WithMessage("Số lượng ảnh không được vượt quá 10");

            RuleForEach(x => x.Images)
                .NotEmpty().WithMessage("File ảnh không được để trống")
                .Must(x => x.Length > 0).WithMessage("File ảnh không được rỗng")
                .Must(x => x.ContentType.StartsWith("image/")).WithMessage("File phải là ảnh");

            RuleFor(x => x)
                .Must(x => x.ProductId.HasValue || x.ProductItemId.HasValue)
                .WithMessage("Phải chỉ định ProductId hoặc ProductItemId");

            RuleFor(x => x.Order)
                .GreaterThanOrEqualTo(0).WithMessage("Order phải lớn hơn hoặc bằng 0");
        }
    }
}
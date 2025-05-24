using FluentValidation;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductImage;

namespace SilverCart.Application.Features.Products.Commands.Delete.DeleteProductImage
{
    public class DeleteProductImageValidator : AbstractValidator<DeleteProductImageCommand>
    {
        public DeleteProductImageValidator()
        {
            RuleFor(x => x.ProductItemId)
                .NotEmpty().WithMessage("ID sản phẩm không được để trống");

            RuleFor(x => x.ImageIds)
                .NotEmpty().WithMessage("Danh sách ID hình ảnh không được để trống");

            RuleForEach(x => x.ImageIds)
                .NotEmpty().WithMessage("ID hình ảnh không được để trống");
        }
    }
}
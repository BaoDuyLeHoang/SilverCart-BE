using FluentValidation;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductVariant;

namespace SilverCart.Application.Features.Products.Commands.Delete.DeleteProductVariant
{
    public class DeleteProductVariantValidator : AbstractValidator<DeleteProductVariantCommand>
    {
        public DeleteProductVariantValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ID sản phẩm không được để trống");

            RuleFor(x => x.VariantId)
                .NotEmpty().WithMessage("ID biến thể không được để trống");
        }
    }
}
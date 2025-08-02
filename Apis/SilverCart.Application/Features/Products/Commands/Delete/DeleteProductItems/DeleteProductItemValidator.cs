using FluentValidation;
using Infrastructures.Features.Products.Commands.Delete.DeleteProductItems;

namespace SilverCart.Application.Features.Products.Commands.Delete.DeleteProductItems
{
    public class DeleteProductItemValidator : AbstractValidator<DeleteProductItemCommand>
    {
        public DeleteProductItemValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ID sản phẩm không được để trống");



            RuleFor(x => x.ItemId)
                .NotEmpty().WithMessage("ID phiên bản sản phẩm không được để trống");
        }
    }
}
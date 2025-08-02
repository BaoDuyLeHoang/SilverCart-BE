using FluentValidation;

namespace Infrastructures.Features.Products.Commands.Delete.DeleteProductImage
{
    public class DeleteProductImageValidator : AbstractValidator<DeleteProductImageCommand>
    {
        public DeleteProductImageValidator()
        {
            RuleFor(x => x.ImageId)
                .NotEmpty().WithMessage("ID ảnh không được để trống");
        }
    }
}
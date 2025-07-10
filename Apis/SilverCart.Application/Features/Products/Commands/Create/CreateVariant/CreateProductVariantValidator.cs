using FluentValidation;

namespace Infrastructures.Features.Products.Commands.Create.CreateVariant;

public class CreateProductVariantValidator : AbstractValidator<CreateProductVariantCommand>
{
    public CreateProductVariantValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required");

        RuleFor(x => x.VariantName)
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Variant name is required and cannot exceed 255 characters");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price must be greater than or equal to 0");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Stock must be greater than or equal to 0");
    }
}
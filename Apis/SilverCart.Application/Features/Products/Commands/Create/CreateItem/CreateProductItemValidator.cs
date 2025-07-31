using FluentValidation;

namespace Infrastructures.Features.Products.Commands.Create.CreateItem;

public class CreateProductItemValidator : AbstractValidator<CreateProductItemCommand>
{
    public CreateProductItemValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required");

        RuleFor(x => x.StoreId)
            .NotEmpty()
            .WithMessage("Store ID is required");

        RuleFor(x => x.SKU)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("SKU is required and cannot exceed 100 characters");

        RuleFor(x => x.OriginalPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Original price must be greater than or equal to 0");

        RuleFor(x => x.DiscountedPrice)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Discounted price must be greater than or equal to 0");

        RuleFor(x => x.Weight)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Weight must be greater than or equal to 0");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Stock must be greater than or equal to 0");

        RuleFor(x => x.DiscountedPrice)
            .LessThanOrEqualTo(x => x.OriginalPrice)
            .WithMessage("Discounted price cannot be greater than original price");
    }
}
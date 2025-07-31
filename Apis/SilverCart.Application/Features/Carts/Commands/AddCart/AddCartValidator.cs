using FluentValidation;

namespace Infrastructures.Features.Carts.Commands.AddCart;

public class AddCartValidator : AbstractValidator<AddCartCommand>
{
    public AddCartValidator()
    {

        RuleFor(x => x.CartItems)
            .NotEmpty()
            .WithMessage("Danh sách CartItems không được để trống.");

        RuleForEach(x => x.CartItems)
            .SetValidator(new CartItemCreateDtoValidator());
    }
}

public class CartItemCreateDtoValidator : AbstractValidator<CartItemCreateDto>
{
    public CartItemCreateDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("ProductId không được để trống.");

        RuleFor(x => x.ProductItemId)
            .NotEmpty()
            .WithMessage("ProductItemId không được để trống.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Số lượng phải lớn hơn 0.");

        RuleFor(x => x.Quantity)
            .LessThanOrEqualTo(100)
            .WithMessage("Số lượng không được vượt quá 100.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Giá phải lớn hơn 0.");
    }
}
using FluentValidation;

namespace Infrastructures.Features.Carts.Commands.UpdateCartItem;

public class UpdateCartItemValidator : AbstractValidator<UpdateCartItemCommand>
{
    public UpdateCartItemValidator()
    {
        RuleFor(x => x.CartItemId)
            .NotEmpty()
            .WithMessage("CartItemId không được để trống.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Số lượng phải lớn hơn 0.");

        RuleFor(x => x.Quantity)
            .LessThanOrEqualTo(100)
            .WithMessage("Số lượng không được vượt quá 100.");
    }
}
using FluentValidation;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStateGuardianConfirm;

namespace SilverCart.Application.Features.Orders.Commands.ChangeState.ChangeOrderItemsStateGuardianConfirm
{
    public class ChangeOrderItemsStateGuardianConfirmValidator : AbstractValidator<ChangeOrderItemsStateProductOfGuardianCommand>
    {
        public ChangeOrderItemsStateGuardianConfirmValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("ID đơn hàng không được để trống");

            RuleFor(x => x.OrderDetailId)
                .NotEmpty().WithMessage("ID đơn hàng cửa hàng không được để trống");
        }
    }
}
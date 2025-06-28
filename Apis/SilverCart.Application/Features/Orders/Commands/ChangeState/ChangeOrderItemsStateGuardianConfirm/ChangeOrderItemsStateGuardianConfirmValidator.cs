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

            RuleFor(x => x.StoreOrderId)
                .NotEmpty().WithMessage("ID đơn hàng cửa hàng không được để trống");

            RuleFor(x => x.StoreProductItemOrderId)
                .NotEmpty().WithMessage("ID sản phẩm đơn hàng không được để trống");
        }
    }
} 
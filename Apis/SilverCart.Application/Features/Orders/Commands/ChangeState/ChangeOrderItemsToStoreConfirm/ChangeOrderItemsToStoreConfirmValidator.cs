using FluentValidation;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsToStoreConfirm;
using SilverCart.Domain.Enums;

namespace SilverCart.Application.Features.Orders.Commands.ChangeState.ChangeOrderItemsToStoreConfirm
{
    public class ChangeOrderItemsToStoreConfirmValidator : AbstractValidator<ChangeOrderItemsToStoreConfirmCommand>
    {
        public ChangeOrderItemsToStoreConfirmValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("ID đơn hàng không được để trống");

            RuleFor(x => x.OrderDetailId)
                .NotEmpty().WithMessage("ID đơn hàng cửa hàng không được để trống");
        }
    }
}
using FluentValidation;
using Infrastructures.Features.Orders.Commands.Create;

namespace SilverCart.Application.Features.Orders.Commands.Create.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.OrderItems)
                .NotEmpty().WithMessage("Danh sách đơn hàng không được để trống");

            RuleForEach(x => x.OrderItems).ChildRules(storeOrder =>
            {
                storeOrder.RuleFor(x => x.StoreId)
                    .NotEmpty().WithMessage("ID cửa hàng không được để trống");

                storeOrder.RuleFor(x => x.StoreProductItemsOrders)
                    .NotEmpty().WithMessage("Danh sách sản phẩm không được để trống");

                storeOrder.RuleForEach(x => x.StoreProductItemsOrders).ChildRules(item =>
                {
                    item.RuleFor(x => x.StoreProductItemId)
                        .NotEmpty().WithMessage("ID sản phẩm không được để trống");

                    item.RuleFor(x => x.Quantity)
                        .GreaterThan(0).WithMessage("Số lượng sản phẩm phải lớn hơn 0")
                        .LessThanOrEqualTo(100).WithMessage("Số lượng sản phẩm không được vượt quá 100");
                });
            });
        }
    }
} 
//using FluentValidation;
//using Infrastructures.Features.Orders.Commands.Update.UpdateOrderItems;

//namespace SilverCart.Application.Features.Orders.Commands.Update.UpdateOrderItems
//{
//    public class UpdateOrderItemsValidator : AbstractValidator<UpdateOrderItemsCommand>
//    {
//        public UpdateOrderItemsValidator()
//        {
//            RuleFor(x => x.OrderId)
//                .NotEmpty().WithMessage("ID đơn hàng không được để trống");

//            RuleFor(x => x.StoreOrderId)
//                .NotEmpty().WithMessage("ID đơn hàng cửa hàng không được để trống");

//            RuleFor(x => x.StoreProductItemOrderId)
//                .NotEmpty().WithMessage("ID sản phẩm đơn hàng không được để trống");

//            RuleFor(x => x.OrderItems).ChildRules(item =>
//            {
//                item.RuleFor(x => x.Quantity)
//                    .GreaterThan(0).WithMessage("Số lượng sản phẩm phải lớn hơn 0")
//                    .LessThanOrEqualTo(100).WithMessage("Số lượng sản phẩm không được vượt quá 100");
//            });
//        }
//    }
//} 
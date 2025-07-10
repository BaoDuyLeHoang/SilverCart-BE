//using FluentValidation;
//using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStatusToShip;
//using SilverCart.Domain.Enums;

//namespace SilverCart.Application.Features.Orders.Commands.ChangeState.ChangeOrderItemsStatusToShip
//{
//    public class ChangeOrderItemsStatusToShipValidator : AbstractValidator<ChangeOrderItemsStatusToShipCommand>
//    {
//        public ChangeOrderItemsStatusToShipValidator()
//        {
//            RuleFor(x => x.OrderId)
//                .NotEmpty().WithMessage("ID đơn hàng không được để trống");

//            RuleFor(x => x.StoreOrderId)
//                .NotEmpty().WithMessage("ID đơn hàng cửa hàng không được để trống");

//            RuleFor(x => x.StoreProductItemOrderId)
//                .NotEmpty().WithMessage("ID sản phẩm đơn hàng không được để trống");

//            RuleFor(x => x.ServiceTypeId)
//                .GreaterThan(0).WithMessage("Loại dịch vụ vận chuyển không hợp lệ");

//            RuleFor(x => x.PaymentTypeId)
//                .GreaterThan(0).WithMessage("Loại thanh toán không hợp lệ");

//            RuleFor(x => x.RequireNote)
//                .IsInEnum().WithMessage("Yêu cầu ghi chú không hợp lệ");
//        }
//    }
//}
//using FluentValidation;
//using Infrastructures.Commons.Paginations;
//using SilverCart.Domain.Enums;

//namespace Infrastructures
//{
//    public class GetAllOrdersValidator : AbstractValidator<GetAllOrdersQuery>
//    {
//        public GetAllOrdersValidator()
//        {
//            When(x => x.PagingRequest != null, () =>
//            {
//                RuleFor(x => x.PagingRequest.Page)
//                    .GreaterThan(0).WithMessage("Số trang phải lớn hơn 0");

//                RuleFor(x => x.PagingRequest.PageSize)
//                    .GreaterThan(0).WithMessage("Kích thước trang phải lớn hơn 0")
//                    .LessThanOrEqualTo(100).WithMessage("Kích thước trang không được vượt quá 100");
//            });

//            When(x => x.OrderStatus.HasValue, () =>
//            {
//                RuleFor(x => x.OrderStatus)
//                    .IsInEnum().WithMessage("Trạng thái đơn hàng không hợp lệ")
//                    .NotEqual(OrderStatusEnums.All).WithMessage("Trạng thái đơn hàng không thể là 'All'");
//            });
//        }
//    }
//} 
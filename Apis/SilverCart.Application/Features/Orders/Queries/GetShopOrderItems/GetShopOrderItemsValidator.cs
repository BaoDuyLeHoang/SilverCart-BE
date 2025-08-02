using FluentValidation;
using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Orders.Queries.GetShopOrderItems;
using SilverCart.Domain.Enums;

namespace SilverCart.Application.Features.Orders.Queries.GetShopOrderItems
{
    public class GetShopOrderItemsValidator : AbstractValidator<GetShopOrderItemsCommand>
    {
        public GetShopOrderItemsValidator()
        {
            RuleFor(x => x.StoreId)
                .NotEmpty().WithMessage("ID cửa hàng không được để trống");

            When(x => x.PagingRequest != null, () =>
            {
                RuleFor(x => x.PagingRequest.Page)
                    .GreaterThan(0).WithMessage("Số trang phải lớn hơn 0");

                RuleFor(x => x.PagingRequest.PageSize)
                    .GreaterThan(0).WithMessage("Kích thước trang phải lớn hơn 0")
                    .LessThanOrEqualTo(100).WithMessage("Kích thước trang không được vượt quá 100");
            });

            When(x => x.FromDate.HasValue && x.ToDate.HasValue, () =>
            {
                RuleFor(x => x.ToDate)
                    .GreaterThanOrEqualTo(x => x.FromDate)
                    .WithMessage("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu");
            });

            When(x => x.OrderStatus.HasValue, () =>
            {
                RuleFor(x => x.OrderStatus)
                    .IsInEnum().WithMessage("Trạng thái đơn hàng không hợp lệ")
                    .NotEqual(Domain.Enums.OrderStatusEnum.All).WithMessage("Trạng thái đơn hàng không thể là 'All'");
            });
        }
    }
}
using FluentValidation;

namespace Infrastructures.Features.Admin.Queries.Promotion
{
    public class GetPromotionDetailValidation : AbstractValidator<GetPromotionDetailQuery>
    {
        public GetPromotionDetailValidation()
        {
            When(x => x.PagingRequest != null, () =>
            {
                RuleFor(x => x.PagingRequest.Page)
                    .GreaterThan(0).WithMessage("Số trang phải lớn hơn 0");

                RuleFor(x => x.PagingRequest.PageSize)
                    .GreaterThan(0).WithMessage("Kích thước trang phải lớn hơn 0")
                    .LessThanOrEqualTo(100).WithMessage("Kích thước trang không được vượt quá 100");
            });
            When(x => !string.IsNullOrEmpty(x.Name), () =>
            {
                RuleFor(x => x.Name)
                    .MaximumLength(100).WithMessage("Tên tìm kiếm không được vượt quá 100 ký tự");
            });

            When(x => x.StartDate.HasValue, () =>
            {
                RuleFor(x => x.StartDate)
                    .Must(date => date.HasValue && date.Value != DateTime.MinValue)
                    .WithMessage("Ngày bắt đầu không hợp lệ.");
            });

            When(x => x.EndDate.HasValue, () =>
            {
                RuleFor(x => x.EndDate)
                    .Must(date => date.HasValue && date.Value != DateTime.MinValue)
                    .WithMessage("Ngày kết thúc không hợp lệ.");
            });

            //EndDate >= StartDate if both are provided
            When(x => x.StartDate.HasValue && x.EndDate.HasValue, () =>
            {
                RuleFor(x => x.EndDate)
                    .GreaterThanOrEqualTo(x => x.StartDate.Value)
                    .WithMessage("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.");
            });
        }
    }
}

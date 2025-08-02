using FluentValidation;

namespace Infrastructures.Features.Users.Queries.GetCustomerUser
{
    public class GetCustomerUserValidation : AbstractValidator<GetCustomerUserQuery>
    {
        public GetCustomerUserValidation()
        {
            When(x => x.PagingRequest != null, () =>
            {
                RuleFor(x => x.PagingRequest.Page)
                    .GreaterThan(0).WithMessage("Số trang phải lớn hơn 0");

                RuleFor(x => x.PagingRequest.PageSize)
                    .GreaterThan(0).WithMessage("Kích thước trang phải lớn hơn 0")
                    .LessThanOrEqualTo(100).WithMessage("Kích thước trang không được vượt quá 100");
            });

            When(x => !string.IsNullOrEmpty(x.Fullname), () =>
            {
                RuleFor(x => x.Fullname)
                    .MaximumLength(100).WithMessage("Họ và tên tìm kiếm không được vượt quá 100 ký tự");
            });

            When(x => !string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email)
                    .MaximumLength(100).WithMessage("Email tìm kiếm không được vượt quá 100 ký tự")
                    .EmailAddress().WithMessage("Địa chỉ email không hợp lệ.");
            });

            When(x => !string.IsNullOrEmpty(x.Phone), () =>
            {
                RuleFor(x => x.Phone)
                    .MaximumLength(20).WithMessage("Số điện thoại tìm kiếm không được vượt quá 11 ký tự")
                    .Matches(@"^(0|\+84)(?:[35789]|2)\d{7,8}$")
                    .WithMessage("Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại Việt Nam hợp lệ (ví dụ: 0912345678 hoặc +84912345678).");
            });

            When(x => x.Gender.HasValue, () =>
            {
                RuleFor(x => x.Gender)
                    .IsInEnum().WithMessage("Giới tính không hợp lệ. Vui lòng chọn một trong các giá trị hợp lệ (Nam, Nữ, Khác).");
            });
        }
    }
}

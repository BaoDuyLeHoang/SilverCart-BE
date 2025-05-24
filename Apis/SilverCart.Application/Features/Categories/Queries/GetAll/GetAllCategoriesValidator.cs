using FluentValidation;
using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Categories.Queries.GetAll;

namespace SilverCart.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoriesValidator : AbstractValidator<GetAllCategoriesQuery>
    {
        public GetAllCategoriesValidator()
        {
            When(x => x.PagingRequest != null, () =>
            {
                RuleFor(x => x.PagingRequest.Page)
                    .GreaterThan(0).WithMessage("Số trang phải lớn hơn 0");

                RuleFor(x => x.PagingRequest.PageSize)
                    .GreaterThan(0).WithMessage("Kích thước trang phải lớn hơn 0")
                    .LessThanOrEqualTo(100).WithMessage("Kích thước trang không được vượt quá 100");
            });

            When(x => !string.IsNullOrEmpty(x.CategoryName), () =>
            {
                RuleFor(x => x.CategoryName)
                    .MaximumLength(100).WithMessage("Tên danh mục tìm kiếm không được vượt quá 100 ký tự");
            });
        }
    }
}
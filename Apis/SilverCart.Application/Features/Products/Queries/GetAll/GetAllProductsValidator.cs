using FluentValidation;
using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Products.Queries.GetAll;

namespace SilverCart.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsValidator : AbstractValidator<GetAllProductsCommand>
    {
        public GetAllProductsValidator()
        {
            When(x => x.PagingRequest != null, () =>
            {
                RuleFor(x => x.PagingRequest.Page)
                    .GreaterThan(0).WithMessage("Số trang phải lớn hơn 0");

                RuleFor(x => x.PagingRequest.PageSize)
                    .GreaterThan(0).WithMessage("Kích thước trang phải lớn hơn 0")
                    .LessThanOrEqualTo(100).WithMessage("Kích thước trang không được vượt quá 100");
            });

            When(x => !string.IsNullOrEmpty(x.ProductName), () =>
            {
                RuleFor(x => x.ProductName)
                    .MaximumLength(200).WithMessage("Tên sản phẩm tìm kiếm không được vượt quá 200 ký tự");
            });
        }
    }
}
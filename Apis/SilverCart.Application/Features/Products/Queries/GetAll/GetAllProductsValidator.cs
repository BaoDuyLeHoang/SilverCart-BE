using FluentValidation;
using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Products.Queries.GetAll;
using SilverCart.Domain.Enums;

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

            RuleFor(x => x.Keyword)
                .MaximumLength(255)
                .When(x => !string.IsNullOrEmpty(x.Keyword))
                .WithMessage("Từ khóa không được vượt quá 255 ký tự");

            RuleFor(x => x.Id)
                .NotEmpty()
                .When(x => x.Id.HasValue)
                .WithMessage("ID sản phẩm không được để trống");
        }
    }
}
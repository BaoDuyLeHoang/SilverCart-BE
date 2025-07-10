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

            RuleFor(x => x.ProductName)
                .MaximumLength(255)
                .When(x => !string.IsNullOrEmpty(x.ProductName))
                .WithMessage("Product name cannot exceed 255 characters");

            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .When(x => !string.IsNullOrEmpty(x.Description))
                .WithMessage("Description cannot exceed 1000 characters");

            RuleFor(x => x.ProductType)
                .IsInEnum()
                .When(x => x.ProductType.HasValue)
                .WithMessage("Invalid product type");

            RuleFor(x => x.Id)
                .NotEmpty()
                .When(x => x.Id.HasValue)
                .WithMessage("Product ID cannot be empty when provided");
        }
    }
}
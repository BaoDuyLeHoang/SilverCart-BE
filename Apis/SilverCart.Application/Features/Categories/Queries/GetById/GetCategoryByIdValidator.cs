using FluentValidation;
using Infrastructures.Features.Categories.Queries.GetById;

namespace SilverCart.Application.Features.Categories.Queries.GetById
{
    public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID danh mục không được để trống");
        }
    }
}
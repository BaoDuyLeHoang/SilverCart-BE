using FluentValidation;
using Infrastructures.Features.Products.Queries.GetById;

namespace SilverCart.Application.Features.Products.Queries.GetById
{
    public class GetProductByIdValidator : AbstractValidator<GetProductByIdCommand>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID sản phẩm không được để trống");
        }
    }
}
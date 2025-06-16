using FluentValidation;

namespace Infrastructures.Features.Orders.Queries.GetById
{
    public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetOrderByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID đơn hàng không được để trống");
        }
    }
} 
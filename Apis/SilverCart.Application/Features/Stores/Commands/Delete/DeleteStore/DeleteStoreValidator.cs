using FluentValidation;
using System;

namespace Infrastructures.Features.Stores.Commands.Delete.DeleteStore
{
    public class DeleteStoreValidator : AbstractValidator<DeleteStoreCommand>
    {
        public DeleteStoreValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage("ID cửa hàng không hợp lệ.");
        }
    }
}
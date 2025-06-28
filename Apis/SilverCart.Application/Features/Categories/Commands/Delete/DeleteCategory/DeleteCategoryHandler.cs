using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Categories.Commands.Delete.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        public DeleteCategoryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
        }

        public async Task<Guid> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new AppExceptions("Category not found");
            }

            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
                throw new AppExceptions("User not authenticated.");

            category.IsDeleted = true;

            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveChangeAsync();

            return category.Id;
        }
    }
}
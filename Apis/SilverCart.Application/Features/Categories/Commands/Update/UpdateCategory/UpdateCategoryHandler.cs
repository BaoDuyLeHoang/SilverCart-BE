using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Categories.Commands.Update.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
        }

        public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
                throw new UnauthorizedAccessException("User not authenticated.");

            var existedCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
            if (existedCategory == null)
            {
                throw new Exception("Category not found");
            }

            if (request.ParentCategoryId.HasValue)
            {
                var parentCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(request.ParentCategoryId.Value);
                if (parentCategory == null)
                {
                    throw new Exception("Parent category not found");
                }
            }
            existedCategory.ParentCategoryId = request.ParentCategoryId;
            existedCategory.Name = request.Name;
            existedCategory.Description = request.Description;
            existedCategory.Status = request.Status;

            _unitOfWork.CategoryRepository.Update(existedCategory);
            await _unitOfWork.SaveChangeAsync();

            return existedCategory.Id;
        }
    }
}
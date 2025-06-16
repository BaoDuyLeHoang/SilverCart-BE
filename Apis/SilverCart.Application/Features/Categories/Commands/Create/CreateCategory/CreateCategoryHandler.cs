using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Categories.Commands.Create.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        public CreateCategoryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
                throw new AppExceptions("User not authenticated.");

            var existedCategory = await _unitOfWork.CategoryRepository.GetAllAsync(x => x.Name == request.Name);
            if (existedCategory.Any())
            {
                throw new AppExceptions("Category already exists");
            }

            if (request.ParentCategoryId.HasValue)
            {
                var parentCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(request.ParentCategoryId.Value);
                if (parentCategory == null)
                {
                    throw new AppExceptions("Parent category not found");
                }
            }

            var category = new Category
            {
                Id = Guid.NewGuid(),
                ParentCategoryId = request.ParentCategoryId,
                Name = request.Name,
                Description = request.Description,
                Status = request.Status,
                ApprovedById = currentUserId
            };

            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangeAsync();

            return category.Id;
        }
    }
}
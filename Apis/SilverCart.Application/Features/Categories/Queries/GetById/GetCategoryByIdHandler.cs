using Infrastructures.Commons.Exceptions;
using Infrastructures.Features.Categories.Queries.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Categories.Queries.GetById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, GetAllCategoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllCategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetAllAsync(
                predicate: x => x.Id == request.Id && !x.IsDeleted,
                include: source => source
                    .Include(x => x.ParentCategory)
                    .Include(x => x.ProductCategories)
            ).ContinueWith(x => x.Result.FirstOrDefault());

            if (category == null)
            {
                throw new AppExceptions("Category not found");
            }

            return new GetAllCategoryResponse(
                category.Id,
                category.Name,
                category.Description,
                category.Status.ToString(),
                category.ParentCategoryId,
                category.ParentCategory != null ? category.ParentCategory.Name : null,
                category.CreationDate,
                category.ProductCategories.Count
            );
        }
    }
}
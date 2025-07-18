using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities.Categories;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Categories.Queries.GetAll
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, PagedResult<GetAllCategoryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<GetAllCategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.CategoryRepository.GetAllAsync(
                predicate: x => !x.IsDeleted,
                include: source => source
                    .Include(x => x.ParentCategory)
                    .Include(x => x.ProductCategories)
            );

            var filteredEntity = new Category
            {
                Id = request.Id.HasValue ? request.Id.Value : Guid.Empty,
                Name = !string.IsNullOrEmpty(request.CategoryName) ? request.CategoryName : string.Empty,
                Status = request.Status.HasValue ? request.Status.Value : CategoryStatusEnum.Active,
                ParentCategoryId = request.ParentCategoryId
            };

            var filteredCategories = query.AsQueryable().CustomFilterV1(filteredEntity);

            var mappedCategories = await filteredCategories
                .Select(category => new GetAllCategoryResponse(
                    category.Id,
                    category.Name,
                    category.Description,
                    category.Status.ToString(),
                    category.ParentCategoryId,
                    category.ParentCategory != null ? category.ParentCategory.Name : null,
                    category.CreationDate,
                    category.ProductCategories.Count
                )).ToListAsync(cancellationToken);

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            var sortedResult = PaginationHelper<GetAllCategoryResponse>.Sorting(sortType, mappedCategories, sortField);
            var result = PaginationHelper<GetAllCategoryResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}
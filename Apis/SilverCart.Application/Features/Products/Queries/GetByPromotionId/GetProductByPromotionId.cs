using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Products.Queries.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Categories;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Queries.GetByPromotionId
{
    public sealed record GetProductByPromotionIdQuery(PagingRequest? PagingRequest, Guid? Id, string? Keyword) : IRequest<PagedResult<GetProductByPromotionIdResponse>>;
    public record GetProductByPromotionIdResponse(Guid? Id, string ProductName, string? Description, string? VideoPath, string ProductType, DateTime? CreationDate, List<ProductCategory> ProductCategories, List<ProductItem> ProductItems);
    public class GetProductByPromotionIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProductByPromotionIdQuery, PagedResult<GetProductByPromotionIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<PagedResult<GetProductByPromotionIdResponse>> Handle(GetProductByPromotionIdQuery request, CancellationToken cancellationToken)
        {
            var promotion = await _unitOfWork.PromotionRepository
                .GetByIdAsync((Guid)request.Id);

            if (promotion == null || !promotion.ProductPromotions.Any())
                throw new KeyNotFoundException($"No products found for promotion ID {request.Id}.");

            var productIds = promotion.ProductPromotions.Select(pp => pp.ProductId).ToList();

            var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: p => productIds.Contains(p.Id),
                include: source => source
                    .Include(x => x.ProductItems)
                        .ThenInclude(i => i.ProductImages)
                    .Include(x => x.ProductCategories)
                        .ThenInclude(pc => pc.Category)
            );

            var mappedProducts = products.Select(product => new GetProductByPromotionIdResponse(
                product.Id,
                product.Name,
                product.Description,
                product.VideoPath,
                product.ProductType.ToString(),
                product.CreationDate,
                product.ProductCategories.ToList(),
                product.ProductItems.ToList()
                )).ToList();

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            var sortedResult = PaginationHelper<GetProductByPromotionIdResponse>.Sorting(sortType, mappedProducts, sortField);
            var result = PaginationHelper<GetProductByPromotionIdResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}

using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Queries.GetAll;
//Keyword sẽ search theo tên sản phẩm, mô tả sản phẩm, tên danh mục, tên phân loại, cả product item
public sealed record GetAllProductsCommand(PagingRequest? PagingRequest, Guid? Id, string? Keyword, ProductTypeEnum? ProductType) : IRequest<PagedResult<GetAllProductsResponse>>;
public record GetAllProductsResponse(Guid Id, string ProductName, string? Description, string? VideoPath, string ProductType, DateTime? CreationDate, List<GetProductCategoriesResponse> ProductCategories, List<GetProductItemsResponse> ProductItems);
public record GetProductCategoriesResponse(Guid Id, string CategoryName);
public record GetProductItemsResponse(Guid Id, string ProductName, decimal OriginalPrice, decimal DiscountedPrice, int Weight, int Stock, bool IsActive, List<GetProductImagesResponse> ProductImages);
public record GetProductImagesResponse(Guid Id, string ImagePath, string ImageName);
public record GetCategoryProductResponse(Guid Id, string CategoryName);

public class GetAllProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllProductsCommand, PagedResult<GetAllProductsResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<PagedResult<GetAllProductsResponse>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(
            predicate: _ => true,
            include: source => source
                .Include(x => x.ProductItems)
                    .ThenInclude(i => i.ProductImages)
                .Include(x => x.ProductImages)
        );

        if (!string.IsNullOrEmpty(request.Keyword))
        {
            products = products.Where(p => p.Name.Contains(request.Keyword) ||
                (p.Description != null && p.Description.Contains(request.Keyword)) ||
                p.ProductCategories.Any(c => c.Category.Name.Contains(request.Keyword)) ||
                p.ProductItems.Any(i => i.ProductName.Contains(request.Keyword)));
        }

        var mappedProducts = products
            .Select(product => new GetAllProductsResponse(
                product.Id,
                product.Name,
                product.Description,
                product.VideoPath,
                product.ProductType.ToString(),
                product.CreationDate,
                product.ProductCategories.Select(category => new GetProductCategoriesResponse(
                    category.CategoryId,
                    category.Category.Name
                )).ToList(),
                product.ProductItems.Select(item => new GetProductItemsResponse(
                    item.Id,
                    item.ProductName,
                    item.OriginalPrice,
                    item.DiscountedPrice,
                    item.Weight,
                    item.Stock.Quantity,
                    item.IsActive,
                    item.ProductImages.Select(img => new GetProductImagesResponse(
                        img.Id,
                        img.ImagePath,
                        img.ImageName
                    )).ToList()
                )).ToList()
            ));

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResult = PaginationHelper<GetAllProductsResponse>.Sorting(sortType, mappedProducts, sortField);
        var result = PaginationHelper<GetAllProductsResponse>.Paging(sortedResult, page, pageSize);

        return result;
    }
}

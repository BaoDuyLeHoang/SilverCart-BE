using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Queries.GetAll;

public sealed record GetAllProductsCommand(PagingRequest? PagingRequest, Guid? Id, string? ProductName, string? Description, ProductTypeEnum? ProductType) : IRequest<PagedResult<GetAllProductsResponse>>;
public record GetAllProductsResponse(Guid Id, string ProductName, string? Description, string? VideoPath, string ProductType, DateTime? CreatedDate, List<GetProductCategoriesResponse> ProductCategories, List<GetProductVariantsResponse> Variants);
public record GetProductCategoriesResponse(Guid Id, string CategoryName);
public record GetProductVariantsResponse(Guid Id, string VariantName, decimal Price, bool IsActive, List<GetProductItemsResponse> ProductItems);
public record GetProductItemsResponse(Guid Id, string SKU, decimal OriginalPrice, decimal DiscountedPrice, int Weight, int Stock, bool IsActive, List<GetProductImagesResponse> ProductImages);
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
                .Include(x => x.Variants)
                    .ThenInclude(v => v.Items)
                        .ThenInclude(i => i.ProductImages)
                .Include(x => x.ProductImages)
        );

        var filteredEntity = new Product
        {
            Id = request.Id ?? Guid.Empty,
            Name = request.ProductName ?? string.Empty,
            Description = request.Description ?? string.Empty,
            ProductType = request.ProductType ?? ProductTypeEnum.All
        };

        var filteredProducts = products.AsQueryable().CustomFilterV1(filteredEntity);

        var mappedProducts = filteredProducts
            .Select(product => new GetAllProductsResponse(
                product.Id,
                product.Name,
                product.Description,
                product.VideoPath,
                product.ProductType.ToString(),
                product.CreationDate,
                product.ProductCategories.Select(category => new GetProductCategoriesResponse(
                    category.Id,
                    category.Category.Name
                )).ToList(),
                product.Variants.Select(variant => new GetProductVariantsResponse(
                    variant.Id,
                    variant.VariantName,
                    variant.Price,
                    variant.IsActive,
                    variant.Items.Select(item => new GetProductItemsResponse(
                        item.Id,
                        item.SKU,
                        item.OriginalPrice,
                        item.DiscountedPrice,
                        item.Weight,
                        item.Stock,
                        item.IsActive,
                        item.ProductImages.Select(img => new GetProductImagesResponse(
                            img.Id,
                            img.ImagePath,
                            img.ImageName
                        )).ToList()
                    )).ToList()
                )).ToList()
            ));

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResult = PaginationHelper<GetAllProductsResponse>.Sorting(sortType, mappedProducts, sortField);
        var result = PaginationHelper<GetAllProductsResponse>.Paging(sortedResult, page, pageSize);

        return result;
    }
}

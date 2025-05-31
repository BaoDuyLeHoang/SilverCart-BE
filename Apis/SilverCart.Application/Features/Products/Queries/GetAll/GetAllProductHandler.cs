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

public sealed record GetAllProductsCommand(PagingRequest? PagingRequest, Guid? Id, string? ProductName, string? Description, ProductTypeEnum? ProductType, List<Guid>? CategoryIds) : IRequest<PagedResult<GetAllProductsResponse>>;
public record GetAllProductsResponse(Guid? Id, string ProductName, string? Description, string? VideoPath, string? ProductType, List<GetCategoryResponse>? Categories, DateTime? CreatedDate, List<GetProductVariantsResponse> ProductVariants);
public record GetCategoryResponse(Guid Id, string CategoryName);
public record GetProductVariantsResponse(Guid Id, string VariantName, decimal Price, List<GetProductItemsResponse> ProductItems);
public record GetProductItemsResponse(Guid Id, string? SKU, decimal OriginalPrice, decimal DiscountedPrice, List<GetProductItemsImagesResponse> ProductImages, List<GetStoreProductItemsResponse> StoreProductItems);
public record GetProductItemsImagesResponse(Guid Id, string ImagePath, string ImageName);
public record GetStoreProductItemsResponse(Guid Id, Guid? StoreId, string? StoreName, int Stock);
public class GetAllProductHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllProductsCommand, PagedResult<GetAllProductsResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<PagedResult<GetAllProductsResponse>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(
            predicate: _ => true,
            include: source => source
                .Include(x => x.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .Include(x => x.Variants)
                    .ThenInclude(v => v.Items)
                        .ThenInclude(i => i.ProductImages)
                .Include(x => x.Variants)
                    .ThenInclude(v => v.Items)
                        .ThenInclude(i => i.StoreProductItems)
                            .ThenInclude(spi => spi.Store)
        );

        var filteredEntity = new Product
        {
            Id = request.Id.HasValue ? request.Id.Value : Guid.Empty,
            Name = !request.ProductName.IsNullOrEmpty() ? request.ProductName : string.Empty,
            Description = !request.Description.IsNullOrEmpty() ? request.Description : string.Empty,
            ProductType = request.ProductType.HasValue ? request.ProductType.Value : ProductTypeEnum.All
        };
        var filteredProduct = products.AsQueryable().CustomFilterV1(filteredEntity);
        if (request.CategoryIds != null && request.CategoryIds.Any())
        {
            filteredProduct = filteredProduct
                .Where(p => p.ProductCategories.Any(pc => request.CategoryIds.Contains(pc.CategoryId)));
        }
        var mappedProducts = filteredProduct
            .Select(product => new GetAllProductsResponse(
                product.Id,
                product.Name,
                product.Description,
                product.VideoPath,
                product.ProductType.ToString(),
                product.ProductCategories
                    .Select(pc => new GetCategoryResponse(
                        pc.CategoryId,
                        pc.Category!.Name
                    )).ToList(),
                product.CreationDate,
                product.Variants.Select(variant => new GetProductVariantsResponse(
                    variant.Id,
                    variant.VariantName,
                    variant.Price,
                    variant.Items.Select(item => new GetProductItemsResponse(
                        item.Id,
                        item.SKU,
                        item.OriginalPrice,
                        item.DiscountedPrice,
                        item.ProductImages.Select(img => new GetProductItemsImagesResponse(
                            img.Id,
                            img.ImagePath,
                            img.ImageName
                        )).ToList(),
                        item.StoreProductItems.Select(spi => new GetStoreProductItemsResponse(
                            spi.Id,
                            spi.StoreId,
                            spi.Store.Name,
                            spi.Stock
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

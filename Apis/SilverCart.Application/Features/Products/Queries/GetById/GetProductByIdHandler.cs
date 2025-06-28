using System;
using System.Linq;
using Infrastructures.Features.Products.Queries.GetAll;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Features.Products.Queries.GetById;
public sealed record GetProductByIdCommand(Guid Id) : IRequest<GetAllProductsResponse>;
public class GetProductByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProductByIdCommand, GetAllProductsResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<GetAllProductsResponse> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.Id,
                include: source => source
                    .Include(x => x.ProductCategories)
                        .ThenInclude(pc => pc.Category)
                    .Include(x => x.Variants!)
                        .ThenInclude(v => v.Items!)
                            .ThenInclude(i => i.ProductImages)
                    .Include(x => x.Variants!)
                        .ThenInclude(v => v.Items!)
                            .ThenInclude(i => i.StoreProductItems!)
                                .ThenInclude(spi => spi.Store)
            );

        var product = products.FirstOrDefault();
        if (product == null) return null!;

        return new GetAllProductsResponse
        (
            Id: product.Id,
            ProductName: product.Name,
            Description: product.Description,
            VideoPath: product.VideoPath,
            ProductType: product.ProductType.ToString(),
            Categories: product.ProductCategories
                .Select(pc => new GetCategoryResponse(
                    pc.CategoryId,
                    pc.Category!.Name
                )).ToList(),
            CreatedDate: product.CreationDate,
            ProductVariants: product.Variants.Select(variant => new GetProductVariantsResponse
            (
                Id: variant.Id,
                VariantName: variant.VariantName,
                Price: variant.Price,
                ProductItems: variant.Items.Select(item => new GetProductItemsResponse
                (
                    Id: item.Id,
                    SKU: item.SKU,
                    OriginalPrice: item.OriginalPrice,
                    DiscountedPrice: item.DiscountedPrice,
                    Weight: item.Weight,
                    ProductImages: item.ProductImages.Select(img => new Infrastructures.Features.Products.Queries.GetAll.GetProductItemsImagesResponse(
                        img.Id,
                        img.ImagePath,
                        img.ImageName
                    )).ToList(),
                    StoreProductItems: item.StoreProductItems.Select(spi => new GetStoreProductItemsResponse
                    (
                        Id: spi.Id,
                        StoreId: spi.StoreId,
                        StoreName: spi.Store.Name,
                        Stock: spi.Stock
                    )).ToList()
                )).ToList()
            )).ToList()
        );
    }
}


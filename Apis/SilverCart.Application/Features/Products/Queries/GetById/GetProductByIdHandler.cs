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
                        .ThenInclude(v => v.ProductItems!)
                            .ThenInclude(i => i.ProductImages)
                    .Include(x => x.Variants!)
                        .ThenInclude(v => v.ProductItems!)
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
            ProductCategories: product.ProductCategories
                .Select(pc => new GetProductCategoriesResponse( // Changed to match the expected type
                    pc.CategoryId,
                    pc.Category.Name
                )).ToList(),
            CreationDate: product.CreationDate,
            Variants: product.Variants.Select(variant => new GetProductVariantsResponse
            (
                Id: variant.Id,
                VariantName: variant.VariantName,
                IsActive: variant.IsActive,
                ProductItems: variant.ProductItems.Select(item => new GetProductItemsResponse
                (
                    Id: item.Id,
                    SKU: item.SKU,
                    OriginalPrice: item.OriginalPrice,
                    DiscountedPrice: item.DiscountedPrice,
                    Weight: item.Weight,
                    Stock: item.Stock.Quantity,
                    IsActive: item.IsActive,
                    ProductImages: item.ProductImages.Select(img => new Infrastructures.Features.Products.Queries.GetAll.GetProductImagesResponse(
                        img.Id,
                        img.ImagePath,
                        img.ImageName
                    )).ToList()
                )).ToList()
            )).ToList()
        );
    }
}


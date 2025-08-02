using System;
using System.Linq;
using Infrastructures.Features.Products.Queries.GetAll;
using System.Collections.Generic;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using Infrastructures.Commons.Exceptions;

namespace Infrastructures.Features.Products.Queries.GetById;
public sealed record GetProductByIdCommand(Guid Id) : IRequest<GetAllProductsResponse>;
public class GetProductByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetProductByIdCommand, GetAllProductsResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<GetAllProductsResponse> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.Id && !x.IsDeleted,
                include: source => source
                    .Include(x => x.ProductCategories)
                        .ThenInclude(pc => pc.Category)
                    .Include(x => x.ProductItems.Where(pi => !pi.IsDeleted))
                        .ThenInclude(i => i.ProductImages.Where(pi => !pi.IsDeleted))
            );

        var product = products.FirstOrDefault();
        if (product == null)
            throw new AppExceptions("Không tìm thấy sản phẩm.");

        return new GetAllProductsResponse
        (
            Id: product.Id,
            ProductName: product.Name ?? string.Empty,
            Description: product.Description ?? string.Empty,
            VideoPath: product.VideoPath ?? string.Empty,
            ProductType: product.ProductType.ToString(),
            ProductCategories: product.ProductCategories?
                .Select(pc => new GetProductCategoriesResponse(
                    pc.CategoryId,
                    pc.Category?.Name ?? string.Empty
                )).ToList() ?? new List<GetProductCategoriesResponse>(),
            CreationDate: product.CreationDate ?? DateTime.UtcNow,
            ProductItems: product.ProductItems?
                .Select(item => new GetProductItemsResponse
                (
                    Id: item.Id,
                    ProductName: item.ProductName ?? string.Empty,
                    OriginalPrice: item.OriginalPrice,
                    DiscountedPrice: item.DiscountedPrice,
                    Weight: item.Weight,
                    Stock: item.Stock?.Quantity ?? 0,
                    IsActive: item.IsActive,
                    ProductImages: item.ProductImages?
                        .Select(img => new Infrastructures.Features.Products.Queries.GetAll.GetProductImagesResponse(
                            img.Id,
                            img.ImagePath ?? string.Empty,
                            img.ImageName ?? string.Empty
                        )).ToList() ?? new List<Infrastructures.Features.Products.Queries.GetAll.GetProductImagesResponse>()
                )).ToList() ?? new List<GetProductItemsResponse>()
        );
    }
}


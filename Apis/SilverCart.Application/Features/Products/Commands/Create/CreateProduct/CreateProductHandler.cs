using AutoMapper;
using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Create.CreateProduct
{
    public sealed record CreateProductCommand(string Name, string Description, string VideoPath, ProductTypeEnum ProductType, List<Guid> CategoryIds, List<CreateProductVariants> ProductVariants) : IRequest<Guid>;
    public sealed record CreateProductVariants(string VariantName, decimal Price, List<CreateProductItemsRequest> ProductItems);
    public record CreateProductItemsRequest(string SKU, int Stock, decimal OriginalPrice, int Weight, decimal DiscountedPrice, List<CreateProductItemsImages> ProductImages);
    public sealed record CreateProductItemsImages(string ImagePath, string ImageName);
    public class CreateProductHandler(IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper) : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        private readonly IMapper _mapper = mapper;
        public async Task<Guid> Handle(CreateProductCommand product, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
                throw new AppExceptions("User not authenticated.");

            var storeUser = (await _unitOfWork.StoreUserRepository
                .GetAllAsync(x => x.Id == currentUserId))
                .FirstOrDefault();

            if (storeUser == null)
                throw new AppExceptions("StoreUser not found for the current user.");

            var storeId = storeUser.StoreId;

            var newProduct = _mapper.Map<Product>(product);
            newProduct.Id = Guid.NewGuid();
            var itemMappings = new List<(ProductItem Item, CreateProductItemsRequest ItemVM)>();

            if (product.ProductVariants is { Count: > 0 })
            {
                newProduct.Variants = product.ProductVariants.Select(variantVM =>
                {
                    var mappedVariant = _mapper.Map<ProductVariant>(variantVM);
                    mappedVariant.Id = Guid.NewGuid();
                    mappedVariant.ProductId = newProduct.Id;

                    mappedVariant.Items = variantVM.ProductItems?.Select(itemVM =>
                    {
                        var mappedItem = _mapper.Map<ProductItem>(itemVM);
                        mappedItem.Id = Guid.NewGuid();
                        mappedItem.VariantId = mappedVariant.Id;
                        mappedItem.ProductImages = itemVM.ProductImages?.Select(imageVM =>
                        {
                            var mappedImage = _mapper.Map<ProductImage>(imageVM);
                            mappedImage.Id = Guid.NewGuid();
                            mappedImage.ProductItemId = mappedItem.Id;
                            return mappedImage;
                        }).ToList();

                        itemMappings.Add((mappedItem, itemVM));

                        return mappedItem;
                    }).ToList() ?? new();

                    return mappedVariant;
                }).ToList();
            }

            if (product.CategoryIds is { Count: > 0 })
            {
                var categories = await _unitOfWork.CategoryRepository
                    .GetAllAsync(x => product.CategoryIds.Contains(x.Id));

                newProduct.ProductCategories = categories.Select(category => new ProductCategory
                {
                    ProductId = newProduct.Id,
                    CategoryId = category.Id
                }).ToList();
            }

            await _unitOfWork.ProductRepository.AddAsync(newProduct);
            await _unitOfWork.SaveChangeAsync();

            if (itemMappings.Count > 0)
            {
                var storeProductItems = itemMappings.Select(pair => new StoreProductItem
                {
                    Id = Guid.NewGuid(),
                    StoreId = storeId,
                    ProductItemId = pair.Item.Id,
                    Stock = pair.ItemVM.Stock
                }).ToList();

                await _unitOfWork.StoreRepository.AddStoreProductItemsAsync(storeProductItems);
                await _unitOfWork.SaveChangeAsync();
            }

            return newProduct.Id;
        }
    }
}

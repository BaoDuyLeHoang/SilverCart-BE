using AutoMapper;
using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Entities.Stocks;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilverCart.Domain.Entities.Categories;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Infrastructure.Commons;
using SilverCart.Application.Interfaces;

namespace Infrastructures.Features.Products.Commands.Create.CreateProduct
{
    public sealed record CreateProductCommand(string Name, string Description, string VideoPath, ProductTypeEnum ProductType, List<Guid> CategoryIds, List<CreateProductItemsRequest> ProductItems) : IRequest<Guid>;
    public record CreateProductItemsRequest(int Stock, decimal OriginalPrice, int Weight, decimal DiscountedPrice, List<CreateProductItemsImages> ProductImages);
    public sealed record CreateProductItemsImages(string ImagePath, string ImageName);
    public class CreateProductHandler(IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper, AppConfiguration appConfiguration, ICurrentTime currentTime) : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        private readonly IMapper _mapper = mapper;
        private readonly StoreSettings _storeSettings = appConfiguration.StoreSettings;
        private readonly ICurrentTime _currentTime = currentTime;
        public async Task<Guid> Handle(CreateProductCommand product, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
                throw new AppExceptions("Không thấy Id tài khoản.");

            var user = await _unitOfWork.UserRepository.GetByIdAsync(currentUserId);
            if (user is not StoreUser storeUser && user is not AdministratorUser administratorUser)
                throw new AppExceptions("Người dùng không có quyền tạo sản phẩm.");

            var store = await _unitOfWork.StoreRepository.GetByIdAsync(_storeSettings.Id);
            if (store == null)
                throw new AppExceptions("Không tìm thấy cửa hàng.");

            var newProduct = _mapper.Map<Product>(product);
            newProduct.Id = Guid.NewGuid();
            newProduct.StoreId = _storeSettings.Id;
            newProduct.CreationDate = _currentTime.GetCurrentTime();
            newProduct.ModificationDate = _currentTime.GetCurrentTime();
            newProduct.CreatedById = currentUserId;
            newProduct.ModificationById = currentUserId;
            newProduct.IsDeleted = false;

            if (product.ProductItems is { Count: > 0 })
            {
                newProduct.ProductItems = product.ProductItems.Select(itemVM =>
                {
                    var mappedItem = _mapper.Map<ProductItem>(itemVM);
                    mappedItem.Id = Guid.NewGuid();
                    mappedItem.ProductId = newProduct.Id;
                    mappedItem.CreationDate = _currentTime.GetCurrentTime();
                    mappedItem.ModificationDate = _currentTime.GetCurrentTime();
                    mappedItem.CreatedById = currentUserId;
                    mappedItem.ModificationById = currentUserId;
                    mappedItem.IsDeleted = false;
                    
                    // Tạo Stock cho ProductItem
                    var stock = new Stock
                    {
                        Id = Guid.NewGuid(),
                        ProductItemId = mappedItem.Id,
                        Quantity = itemVM.Stock,
                        AvailableQuantity = itemVM.Stock,
                        ReservedQuantity = 0,
                        SoldQuantity = 0,
                        ReturnedQuantity = 0,
                        DamagedQuantity = 0,
                        CreationDate = _currentTime.GetCurrentTime(),
                        ModificationDate = _currentTime.GetCurrentTime(),
                        CreatedById = currentUserId,
                        ModificationById = currentUserId,
                        IsDeleted = false
                    };
                    
                    mappedItem.StockId = stock.Id;
                    mappedItem.Stock = stock;
                    
                    mappedItem.ProductImages = itemVM.ProductImages?.Select(imageVM =>
                    {
                        if (imageVM == null) return null!;
                        var mappedImage = _mapper.Map<ProductImage>(imageVM);
                        mappedImage.Id = Guid.NewGuid();
                        mappedImage.ProductItemId = mappedItem.Id;
                        mappedImage.CreationDate = _currentTime.GetCurrentTime();
                        mappedImage.ModificationDate = _currentTime.GetCurrentTime();
                        mappedImage.CreatedById = currentUserId;
                        mappedImage.ModificationById = currentUserId;
                        mappedImage.IsDeleted = false;
                        return mappedImage;
                    }).ToList() ?? new List<ProductImage>();

                    return mappedItem;
                }).ToList();
            }

            if (product.CategoryIds is { Count: > 0 })
            {
                var categories = await _unitOfWork.CategoryRepository
                    .GetAllAsync(x => product.CategoryIds.Contains(x.Id));

                newProduct.ProductCategories = categories.Select(category => new ProductCategory
                {
                    ProductId = newProduct.Id,
                    CategoryId = category.Id,
                    CreationDate = _currentTime.GetCurrentTime(),
                    ModificationDate = _currentTime.GetCurrentTime(),
                    CreatedById = currentUserId,
                    ModificationById = currentUserId
                }).ToList();
            }

            await _unitOfWork.ProductRepository.AddAsync(newProduct);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return newProduct.Id;
        }
    }
}

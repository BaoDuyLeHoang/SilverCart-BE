using AutoMapper;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Entities.Stocks;
using SilverCart.Application.Interfaces;
using Infrastructures.Commons.Exceptions;

namespace Infrastructures.Features.Products.Commands.AddProductItems
{
    public sealed record AddProductItemsCommand(Guid ProductId, CreateProductItemsRequest ProductItems) : IRequest<Guid>;
    public class AddProductItemsHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, IClaimsService claimsService) : IRequestHandler<AddProductItemsCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly ICurrentTime _currentTime = currentTime;
        private readonly IClaimsService _claimsService = claimsService;
        
        public async Task<Guid> Handle(AddProductItemsCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
                throw new AppExceptions("Người dùng không được xác thực.");

            var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductId,
                include: source => source.Include(x => x.ProductItems!)
            );

            var product = products.FirstOrDefault();
            if (product is null)
                throw new AppExceptions($"Product with ID '{request.ProductId}' was not found.");

            // Create ProductItem manually instead of using AutoMapper
            var newItem = new ProductItem
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                ProductName = request.ProductItems.Stock.ToString(), // Default name
                OriginalPrice = request.ProductItems.OriginalPrice,
                DiscountedPrice = request.ProductItems.DiscountedPrice,
                Weight = request.ProductItems.Weight,
                CreationDate = _currentTime.GetCurrentTime(),
                ModificationDate = _currentTime.GetCurrentTime(),
                CreatedById = currentUserId,
                ModificationById = currentUserId,
                IsDeleted = false
            };

            // Create Stock for ProductItem
            var stock = new Stock
            {
                Id = Guid.NewGuid(),
                ProductItemId = newItem.Id,
                Quantity = request.ProductItems.Stock,
                AvailableQuantity = request.ProductItems.Stock,
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

            newItem.StockId = stock.Id;
            newItem.Stock = stock;

            // Add ProductImages if provided
            if (request.ProductItems.ProductImages?.Any() == true)
            {
                newItem.ProductImages = request.ProductItems.ProductImages.Select(imageVM =>
                {
                    var mappedImage = new ProductImage
                    {
                        Id = Guid.NewGuid(),
                        ProductItemId = newItem.Id,
                        ImagePath = imageVM.ImagePath,
                        ImageName = imageVM.ImageName,
                        CreationDate = _currentTime.GetCurrentTime(),
                        ModificationDate = _currentTime.GetCurrentTime(),
                        CreatedById = currentUserId,
                        ModificationById = currentUserId,
                        IsDeleted = false
                    };
                    return mappedImage;
                }).ToList();
            }

            product.ProductItems.Add(newItem);

            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            return product.Id;
        }
    }
}

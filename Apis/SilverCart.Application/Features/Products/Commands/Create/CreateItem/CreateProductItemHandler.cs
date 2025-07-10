using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Products.Commands.Create.CreateItem;

public class CreateProductItemHandler : IRequestHandler<CreateProductItemCommand, CreateProductItemResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateProductItemResponse> Handle(CreateProductItemCommand request, CancellationToken cancellationToken)
    {
        // Check if variant exists
        var variant = await _unitOfWork.ProductVariantRepository.GetByIdAsync(request.VariantId);
        if (variant == null)
        {
            throw new ArgumentException($"Product variant with ID {request.VariantId} not found");
        }

        // Check if store exists
        var store = await _unitOfWork.StoreRepository.GetByIdAsync(request.StoreId);
        if (store == null)
        {
            throw new ArgumentException($"Store with ID {request.StoreId} not found");
        }

        var existingItem = await _unitOfWork.ProductItemRepository.GetAllAsync(
            predicate: item => item.SKU == request.SKU && item.VariantId == request.VariantId && item.StoreId == request.StoreId,
            include: source => source.Include(item => item.Variant).ThenInclude(variant => variant.Product)
            );
        if (existingItem != null)
        {
            throw new ArgumentException($"Product item with SKU {request.SKU} already exists");
        }

        var item = new ProductItem
        {
            VariantId = request.VariantId,
            StoreId = request.StoreId,
            SKU = request.SKU,
            OriginalPrice = request.OriginalPrice,
            DiscountedPrice = request.DiscountedPrice,
            Weight = request.Weight,
            Stock = request.Stock,
            IsActive = request.IsActive
        };

        await _unitOfWork.ProductItemRepository.AddAsync(item);
        await _unitOfWork.SaveChangeAsync();

        return new CreateProductItemResponse(
            item.Id,
            item.VariantId,
            item.StoreId,
            item.SKU,
            item.OriginalPrice,
            item.DiscountedPrice,
            item.Weight,
            item.Stock,
            item.IsActive,
            item.CreationDate ?? DateTime.UtcNow
        );
    }
}
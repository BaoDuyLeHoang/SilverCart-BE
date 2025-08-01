using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Entities.Stocks;

namespace Infrastructures.Features.Products.Commands.Create.CreateItem;

public class CreateProductItemHandler : IRequestHandler<CreateProductItemCommand, CreateProductItemResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateProductItemResponse> Handle(CreateProductItemCommand request,
        CancellationToken cancellationToken)
    {
        // Check if product exists
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
        if (product == null)
        {
            throw new ArgumentException($"Product with ID {request.ProductId} not found");
        }

        // Check if store exists
        var store = await _unitOfWork.StoreRepository.GetByIdAsync(request.StoreId);
        if (store == null)
        {
            throw new ArgumentException($"Store with ID {request.StoreId} not found");
        }

        var existingItem = await _unitOfWork.ProductItemRepository.GetAllAsync(
            predicate: item =>
                item.ProductName == request.ProductName && item.ProductId == request.ProductId && item.StoreId == request.StoreId,
            include: source => source.Include(item => item.Product)
        );
        if (existingItem != null)
        {
            throw new ArgumentException($"Product item with ProductName {request.ProductName} already exists");
        }

        var item = new ProductItem
        {
            ProductId = request.ProductId,
            ProductName = request.ProductName,
            OriginalPrice = request.OriginalPrice,
            DiscountedPrice = request.DiscountedPrice,
            Weight = request.Weight,
            Stock = new Stock
            {
                Quantity = request.Stock,
            },
            IsActive = request.IsActive
        };

        await _unitOfWork.ProductItemRepository.AddAsync(item);
        await _unitOfWork.SaveChangeAsync();

        return new CreateProductItemResponse(
            item.Id,
            item.ProductId,
            item.ProductName,
            item.OriginalPrice,
            item.DiscountedPrice,
            item.Weight,
            item.Stock.Quantity,
            item.IsActive,
            item.CreationDate ?? DateTime.UtcNow
        );
    }
}
using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Features.Products.Commands.Update.UpdateProductItems;
public sealed record UpdateProductItemsCommand(Guid ProductId, Guid VariantId, Guid ItemId, UpdateProductItemsRequest ProductItems) : IRequest<Guid>;
public record UpdateProductItemsRequest(string? SKU, int Stock, decimal OriginalPrice, decimal DiscountedPrice);
public class UpdateProductItemsHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateProductItemsCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<Guid> Handle(UpdateProductItemsCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductId,
                include: source => source
                    .Include(p => p.Variants)
                        .ThenInclude(v => v.Items)
            );
        var product = products.FirstOrDefault();
        if (product == null)
            throw new KeyNotFoundException($"Product with ID '{request.ProductId}' not found.");

        var variant = product.Variants.FirstOrDefault(v => v.Id == request.VariantId);
        if (variant == null)
            throw new KeyNotFoundException($"Variant with ID '{request.VariantId}' not found in product '{request.ProductId}'.");

        var item = variant.Items.FirstOrDefault(i => i.Id == request.ItemId);
        if (item == null)
            throw new KeyNotFoundException($"Item with ID '{request.ItemId}' not found.");

        _mapper.Map(request, item);

        item.SKU = request.ProductItems.SKU ?? item.SKU;
        item.OriginalPrice = request.ProductItems.OriginalPrice;
        item.DiscountedPrice = request.ProductItems.DiscountedPrice;

        await _unitOfWork.SaveChangeAsync();
        return product.Id;
    }
}

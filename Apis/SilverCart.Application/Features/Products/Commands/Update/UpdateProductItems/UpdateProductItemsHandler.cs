using System;
using AutoMapper;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Features.Products.Commands.Update.UpdateProductItems;
public sealed record UpdateProductItemsCommand(Guid ProductId, Guid ItemId, UpdateProductItemsRequest ProductItems) : IRequest<Guid>;
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
                    .Include(p => p.ProductItems)
            );
        var product = products.FirstOrDefault();
        if (product == null)
            throw new AppExceptions($"Product with ID '{request.ProductId}' not found.");

        var item = product.ProductItems.FirstOrDefault(i => i.Id == request.ItemId);
        if (item == null)
            throw new AppExceptions($"Item with ID '{request.ItemId}' not found.");

        _mapper.Map(request, item);

        item.SKU = request.ProductItems.SKU ?? item.SKU;
        item.OriginalPrice = request.ProductItems.OriginalPrice;
        item.DiscountedPrice = request.ProductItems.DiscountedPrice;

        await _unitOfWork.SaveChangeAsync();
        return product.Id;
    }
}

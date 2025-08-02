using System;
using AutoMapper;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;

namespace Infrastructures.Features.Products.Commands.Update.UpdateProductItems;
public sealed record UpdateProductItemsCommand(Guid ProductId, Guid ItemId, UpdateProductItemsRequest ProductItems) : IRequest<Guid>;
public record UpdateProductItemsRequest(string? ProductName, int Stock, decimal OriginalPrice, decimal DiscountedPrice);
public class UpdateProductItemsHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, IClaimsService claimsService) : IRequestHandler<UpdateProductItemsCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly ICurrentTime _currentTime = currentTime;
    private readonly IClaimsService _claimsService = claimsService;
    
    public async Task<Guid> Handle(UpdateProductItemsCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
            throw new AppExceptions("Người dùng không được xác thực.");

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

        // Update item properties manually instead of using AutoMapper
        if (!string.IsNullOrWhiteSpace(request.ProductItems.ProductName))
        {
            item.ProductName = request.ProductItems.ProductName;
        }
        item.OriginalPrice = request.ProductItems.OriginalPrice;
        item.DiscountedPrice = request.ProductItems.DiscountedPrice;
        
        // Update audit fields
        item.ModificationDate = _currentTime.GetCurrentTime();
        item.ModificationById = currentUserId;

        await _unitOfWork.SaveChangeAsync(cancellationToken);
        return product.Id;
    }
}

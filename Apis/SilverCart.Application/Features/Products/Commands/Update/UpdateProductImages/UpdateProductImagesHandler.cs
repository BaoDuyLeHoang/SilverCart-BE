using System;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Features.Products.Commands.Update.UpdateProductImages;
public sealed record UpdateProductImagesCommand(Guid ProductItemId, List<UpdateProductImagesRequest> ProductImages) : IRequest<Guid>;
public record UpdateProductImagesRequest(Guid Id, string ImagePath, string ImageName);
public class UpdateProductImagesHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateProductImagesCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    public async Task<Guid> Handle(UpdateProductImagesCommand request, CancellationToken cancellationToken)
    {
        var productItems = await _unitOfWork.ProductItemRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductItemId,
                include: source => source.Include(x => x.ProductImages)
            );

        var productItem = productItems.FirstOrDefault();

        if (productItem == null)
            throw new KeyNotFoundException($"Product with ID '{request.ProductItemId}' not found.");

        foreach (var imageRequest in request.ProductImages)
        {
            var productImage = productItem.ProductImages.FirstOrDefault(x => x.Id == imageRequest.Id);
            if (productImage != null)
                _mapper.Map(imageRequest, productImage);
            else
                throw new KeyNotFoundException($"Image with ID '{imageRequest.Id}' not found.");
        }
        await _unitOfWork.SaveChangeAsync();
        return productItem.Id;
    }
}

using System;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Features.Products.Commands.Update.UpdateProductVariant;
public sealed record UpdateProductVariantCommand(Guid ProductId, Guid VariantId, UpdateProductVariantRequest ProductVariant) : IRequest<Guid>;
public record UpdateProductVariantRequest(string VariantName, decimal Price);
public class UpdateProductVariantHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductVariantCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Guid> Handle(UpdateProductVariantCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductId,
                include: source => source.Include(x => x.Variants)
            );

        var product = products.FirstOrDefault();
        if (product == null)
            throw new AppExceptions($"Product with ID '{request.ProductId}' not found.");

        var variant = product.Variants.FirstOrDefault(x => x.Id == request.VariantId);

        if (variant == null)
            throw new AppExceptions($"Variant with ID '{request.VariantId}' not found in product '{request.ProductId}'.");

        variant.VariantName = request.ProductVariant.VariantName;
        variant.Price = request.ProductVariant.Price;

        await _unitOfWork.SaveChangeAsync();
        return product.Id;
    }
}

using MediatR;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Products.Commands.Create.CreateVariant;

public class CreateProductVariantHandler : IRequestHandler<CreateProductVariantCommand, CreateProductVariantResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductVariantHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateProductVariantResponse> Handle(CreateProductVariantCommand request, CancellationToken cancellationToken)
    {
        // Check if product exists
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
        if (product == null)
        {
            throw new ArgumentException($"Product with ID {request.ProductId} not found");
        }

        var variant = new ProductVariant
        {
            ProductId = request.ProductId,
            VariantName = request.VariantName,
            IsActive = request.IsActive
        };

        await _unitOfWork.ProductVariantRepository.AddAsync(variant);
        await _unitOfWork.SaveChangeAsync();

        return new CreateProductVariantResponse(
            variant.Id,
            variant.ProductId,
            variant.VariantName,
            variant.IsActive,
            variant.CreationDate!.Value
        );
    }
}
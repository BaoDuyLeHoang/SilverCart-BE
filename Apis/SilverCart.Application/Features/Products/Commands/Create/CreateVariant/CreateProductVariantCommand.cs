using MediatR;

namespace Infrastructures.Features.Products.Commands.Create.CreateVariant;

public sealed record CreateProductVariantCommand(
    Guid ProductId,
    string VariantName,
    decimal Price,
    int Stock = 0,
    bool IsActive = true
) : IRequest<CreateProductVariantResponse>;

public record CreateProductVariantResponse(
    Guid Id,
    Guid ProductId,
    string VariantName,
    decimal Price,
    int Stock,
    bool IsActive,
    DateTime CreatedDate
);
using MediatR;

namespace Infrastructures.Features.Products.Commands.Create.CreateItem;

public sealed record CreateProductItemCommand(
    Guid ProductId,
    Guid StoreId,
    string ProductName,
    decimal OriginalPrice,
    decimal DiscountedPrice,
    int Weight,
    int Stock = 0,
    bool IsActive = true
) : IRequest<CreateProductItemResponse>;

public record CreateProductItemResponse(
    Guid Id,
    Guid ProductId,
    string ProductName,
    decimal OriginalPrice,
    decimal DiscountedPrice,
    int Weight,
    int Stock,
    bool IsActive,
    DateTime CreationDate
);
namespace Infrastructures.Features.Carts.Commands.AddCart;

public record CartItemCreateDto(
    Guid ProductId,
    Guid ProductItemId,
    int Quantity,
    decimal Price,
    bool IsSelected = true
);
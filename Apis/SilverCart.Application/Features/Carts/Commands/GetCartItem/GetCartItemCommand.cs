using MediatR;

namespace Infrastructures.Features.Carts.Commands.GetCartItem;

public sealed record GetCartItemCommand(Guid CartItemId) : IRequest<GetCartItemResponse>;

public record GetCartItemResponse(
    Guid CartItemId,
    Guid CartId,
    Guid ProductId,
    Guid ProductItemId,
    int Quantity,
    decimal Price,
    decimal TotalPrice,
    bool IsSelected,
    DateTime CreationDate
);
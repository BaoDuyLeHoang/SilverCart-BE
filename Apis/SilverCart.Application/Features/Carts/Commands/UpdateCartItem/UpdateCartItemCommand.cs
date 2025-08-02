using MediatR;

namespace Infrastructures.Features.Carts.Commands.UpdateCartItem;

public sealed record UpdateCartItemCommand(
    Guid CartItemId,
    int? Quantity = null,
    decimal? Price = null,
    bool? IsSelected = null
) : IRequest<UpdateCartItemResponse>;

public record UpdateCartItemResponse(
    Guid CartItemId,
    Guid CartId,
    Guid ProductId,
    Guid ProductItemId,
    int Quantity,
    decimal Price,
    decimal TotalPrice,
    bool IsSelected,
    DateTime ModificationDate
);
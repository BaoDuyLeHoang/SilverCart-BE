using MediatR;

namespace Infrastructures.Features.Carts.Queries.GetCart;

public sealed record GetCartQuery(Guid CartId) : IRequest<GetCartResponse>;

public record GetCartResponse(
    Guid CartId,
    Guid CustomerUserId,
    Guid GuardianUserId,
    bool ConsultantRecommendation,
    decimal TotalPrice,
    DateTime CreationDate,
    List<CartItemResponse> CartItems
);

public record CartItemResponse(
    Guid CartItemId,
    Guid ProductId,
    Guid ProductItemId,
    int Quantity,
    decimal Price,
    decimal TotalPrice,
    bool IsSelected,
    DateTime CreationDate
);
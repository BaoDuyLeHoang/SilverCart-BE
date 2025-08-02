using MediatR;

namespace Infrastructures.Features.Carts.Queries.GetMyCart;

public sealed record GetMyCartQuery() : IRequest<List<GetMyCartResponse>>;

public record GetMyCartResponse(
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
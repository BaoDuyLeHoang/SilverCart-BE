using MediatR;
using Infrastructures.Features.Carts.Commands.AddCart;

namespace Infrastructures.Features.Carts.Commands.AddCart;

public sealed record AddCartCommand(
    Guid CustomerUserId,
    Guid GuardianUserId,
    bool ConsultantRecommendation,
    List<CartItemCreateDto> CartItems
) : IRequest<AddCartResponse>;

public record AddCartResponse(
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
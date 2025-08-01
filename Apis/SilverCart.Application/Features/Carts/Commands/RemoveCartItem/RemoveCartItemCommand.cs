using MediatR;

namespace Infrastructures.Features.Carts.Commands.RemoveCartItem;

public sealed record RemoveCartItemCommand(Guid CartItemId) : IRequest<bool>;
using MediatR;

namespace Infrastructures.Features.Carts.Commands.DeleteCart;

public sealed record DeleteCartCommand(Guid CartId) : IRequest<bool>;
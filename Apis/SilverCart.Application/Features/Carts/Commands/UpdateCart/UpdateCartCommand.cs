using MediatR;

namespace Infrastructures.Features.Carts.Commands.UpdateCart;

public sealed record UpdateCartCommand(
    Guid CartId,
    bool? ConsultantRecommendation = null
) : IRequest<UpdateCartResponse>;

public record UpdateCartResponse(
    Guid CartId,
    Guid CustomerUserId,
    Guid GuardianUserId,
    bool ConsultantRecommendation,
    decimal TotalPrice,
    DateTime ModificationDate
);
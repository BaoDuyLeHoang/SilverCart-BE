using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Carts;

namespace Infrastructures.Features.Carts.Commands.UpdateCart;

public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCartHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCartResponse> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.CartRepository.GetByIdAsync(request.CartId);
        if (cart == null)
            throw new AppExceptions($"Không tìm thấy Cart với ID {request.CartId}.");

        if (request.ConsultantRecommendation.HasValue)
        {
            cart.IsConsultantUserRecommend = request.ConsultantRecommendation.Value;
        }

        cart.ModificationDate = DateTime.UtcNow;
        _unitOfWork.CartRepository.Update(cart);
        await _unitOfWork.SaveChangeAsync(cancellationToken);

        return new UpdateCartResponse(
            cart.Id,
            cart.UserId ?? Guid.Empty,
            cart.ConsultantUserId ?? Guid.Empty,
            cart.IsConsultantUserRecommend,
            cart.TotalPrice,
            cart.ModificationDate ?? DateTime.UtcNow
        );
    }
}
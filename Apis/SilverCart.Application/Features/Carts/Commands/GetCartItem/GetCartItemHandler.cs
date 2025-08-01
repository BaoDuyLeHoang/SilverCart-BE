using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Carts;

namespace Infrastructures.Features.Carts.Commands.GetCartItem;

public class GetCartItemHandler : IRequestHandler<GetCartItemCommand, GetCartItemResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCartItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetCartItemResponse> Handle(GetCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _unitOfWork.CartItemRepository.GetByIdAsync(request.CartItemId);
        if (cartItem == null || cartItem.IsDeleted)
            throw new AppExceptions($"Không tìm thấy CartItem với ID {request.CartItemId}.");

        return new GetCartItemResponse(
            cartItem.Id,
            cartItem.CartId,
            cartItem.ProductId,
            cartItem.ProductItemId,
            cartItem.Quantity,
            cartItem.Price,
            cartItem.TotalPrice,
            cartItem.IsSelected,
            cartItem.CreationDate ?? DateTime.UtcNow
        );
    }
}
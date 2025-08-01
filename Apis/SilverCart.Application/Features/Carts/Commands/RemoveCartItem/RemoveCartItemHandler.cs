using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Carts;

namespace Infrastructures.Features.Carts.Commands.RemoveCartItem;

public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCartItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _unitOfWork.CartItemRepository.GetByIdAsync(request.CartItemId);
        if (cartItem == null || cartItem.IsDeleted)
            throw new AppExceptions($"Không tìm thấy CartItem với ID {request.CartItemId}.");

        // Soft delete the cart item
        cartItem.IsDeleted = true;
        cartItem.DeletionDate = DateTime.UtcNow;
        _unitOfWork.CartItemRepository.Update(cartItem);

        // Update cart total price
        var cart = await _unitOfWork.CartRepository.GetAllAsync(
            predicate: c => c.Id == cartItem.CartId && !c.IsDeleted,
            include: source => source.Include(c => c.CartItems.Where(ci => !ci.IsDeleted))
        );

        var userCart = cart.FirstOrDefault();
        if (userCart != null)
        {
            userCart.TotalPrice = userCart.CartItems.Sum(ci => ci.TotalPrice);
            _unitOfWork.CartRepository.Update(userCart);
        }

        var result = await _unitOfWork.SaveChangeAsync(cancellationToken) > 0;
        return result;
    }
}
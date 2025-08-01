using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Carts;

namespace Infrastructures.Features.Carts.Commands.DeleteCart;

public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCartHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.CartRepository.GetAllAsync(
            predicate: c => c.Id == request.CartId && !c.IsDeleted,
            include: source => source.Include(c => c.CartItems.Where(ci => !ci.IsDeleted))
        );

        var userCart = cart.FirstOrDefault();
        if (userCart == null)
            throw new AppExceptions($"Không tìm thấy Cart với ID {request.CartId}.");

        // Soft delete all cart items
        foreach (var cartItem in userCart.CartItems)
        {
            cartItem.IsDeleted = true;
            cartItem.DeletionDate = DateTime.UtcNow;
            _unitOfWork.CartItemRepository.Update(cartItem);
        }

        // Soft delete the cart
        userCart.IsDeleted = true;
        userCart.DeletionDate = DateTime.UtcNow;
        _unitOfWork.CartRepository.Update(userCart);

        var result = await _unitOfWork.SaveChangeAsync(cancellationToken) > 0;
        return result;
    }
}
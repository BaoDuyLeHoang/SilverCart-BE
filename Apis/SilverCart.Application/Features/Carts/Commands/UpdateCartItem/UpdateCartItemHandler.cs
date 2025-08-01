using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Carts;

namespace Infrastructures.Features.Carts.Commands.UpdateCartItem;

public class UpdateCartItemHandler : IRequestHandler<UpdateCartItemCommand, UpdateCartItemResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCartItemHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCartItemResponse> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _unitOfWork.CartItemRepository.GetByIdAsync(request.CartItemId);
        if (cartItem == null || cartItem.IsDeleted)
            throw new AppExceptions($"Không tìm thấy CartItem với ID {request.CartItemId}.");

        // Update fields if provided
        if (request.Quantity.HasValue)
        {
            if (request.Quantity.Value <= 0)
                throw new AppExceptions("Số lượng phải lớn hơn 0.");
            cartItem.Quantity = request.Quantity.Value;
        }

        if (request.Price.HasValue)
        {
            if (request.Price.Value <= 0)
                throw new AppExceptions("Giá phải lớn hơn 0.");
            cartItem.Price = request.Price.Value;
        }

        if (request.IsSelected.HasValue)
        {
            cartItem.IsSelected = request.IsSelected.Value;
        }

        // Recalculate total price
        cartItem.TotalPrice = cartItem.Quantity * cartItem.Price;
        cartItem.ModificationDate = DateTime.UtcNow;

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

        await _unitOfWork.SaveChangeAsync(cancellationToken);

        return new UpdateCartItemResponse(
            cartItem.Id,
            cartItem.CartId,
            cartItem.ProductId,
            cartItem.ProductItemId,
            cartItem.Quantity,
            cartItem.Price,
            cartItem.TotalPrice,
            cartItem.IsSelected,
            cartItem.ModificationDate ?? DateTime.UtcNow
        );
    }
}
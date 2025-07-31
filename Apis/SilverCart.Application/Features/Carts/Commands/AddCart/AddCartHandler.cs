using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Carts;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Entities.Stores;

namespace Infrastructures.Features.Carts.Commands.AddCart;

public class AddCartHandler : IRequestHandler<AddCartCommand, AddCartResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddCartHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddCartResponse> Handle(AddCartCommand request, CancellationToken cancellationToken)
    {


        // Create new Cart
        var cart = new Cart
        {
            CustomerUserId = request.CustomerUserId,
            GuardianUserId = request.GuardianUserId,
            ConsultantRecommendation = request.ConsultantRecommendation,
            TotalPrice = 0,
            IsConsultantUserRecommend = false
        };

        await _unitOfWork.CartRepository.AddAsync(cart);

        var cartItems = new List<CartItemResponse>();
        decimal totalPrice = 0;

        // Create CartItems
        foreach (var itemDto in request.CartItems)
        {
            // Validate Product exists
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(itemDto.ProductId);
            if (product == null)
                throw new AppExceptions($"Không tìm thấy Product với ID {itemDto.ProductId}.");

            // Validate ProductItem exists
            var productItem = await _unitOfWork.ProductItemRepository.GetByIdAsync(itemDto.ProductItemId);
            if (productItem == null)
                throw new AppExceptions($"Không tìm thấy ProductItem với ID {itemDto.ProductItemId}.");

            // Get Store from Product
            var store = await _unitOfWork.StoreRepository.GetByIdAsync(product.StoreId);
            if (store == null)
                throw new AppExceptions($"Không tìm thấy Store với ID {product.StoreId}.");

            var cartItem = new CartItem
            {
                CartId = cart.Id, // Bắt buộc gán CartId
                ProductId = itemDto.ProductId,
                ProductItemId = itemDto.ProductItemId,
                StoreId = product.StoreId,
                Quantity = itemDto.Quantity,
                Price = itemDto.Price,
                TotalPrice = itemDto.Quantity * itemDto.Price,
                IsSelected = itemDto.IsSelected
            };

            await _unitOfWork.CartItemRepository.AddAsync(cartItem);

            cartItems.Add(new CartItemResponse(
                cartItem.Id,
                cartItem.ProductId,
                cartItem.ProductItemId,
                cartItem.Quantity,
                cartItem.Price,
                cartItem.TotalPrice,
                cartItem.IsSelected,
                cartItem.CreationDate ?? DateTime.UtcNow
            ));

            totalPrice += cartItem.TotalPrice;
        }

        // Update cart total price
        cart.TotalPrice = totalPrice;
        _unitOfWork.CartRepository.Update(cart);

        await _unitOfWork.SaveChangeAsync(cancellationToken);

        return new AddCartResponse(
            cart.Id,
            cart.CustomerUserId!.Value,
            cart.GuardianUserId!.Value,
            cart.ConsultantRecommendation,
            cart.TotalPrice,
            cart.CreationDate ?? DateTime.UtcNow,
            cartItems
        );
    }
}
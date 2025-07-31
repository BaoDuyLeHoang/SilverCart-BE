using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Carts;

namespace Infrastructures.Features.Carts.Queries.GetCart;

public class GetCartHandler : IRequestHandler<GetCartQuery, GetCartResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCartHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetCartResponse> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _unitOfWork.CartRepository.GetAllAsync(
            predicate: c => c.Id == request.CartId && !c.IsDeleted,
            include: source => source
                .Include(c => c.CartItems.Where(ci => !ci.IsDeleted))
                .ThenInclude(ci => ci.Product)
                .Include(c => c.CartItems.Where(ci => !ci.IsDeleted))
                .ThenInclude(ci => ci.ProductItem)
        );

        var userCart = cart.FirstOrDefault();
        if (userCart == null)
            throw new AppExceptions($"Không tìm thấy Cart với ID {request.CartId}.");

        var cartItems = userCart.CartItems.Select(ci => new CartItemResponse(
            ci.Id,
            ci.ProductId,
            ci.ProductItemId,
            ci.Quantity,
            ci.Price,
            ci.TotalPrice,
            ci.IsSelected,
            ci.CreationDate ?? DateTime.UtcNow
        )).ToList();

        return new GetCartResponse(
            userCart.Id,
            userCart.CustomerUserId!.Value,
            userCart.GuardianUserId!.Value,
            userCart.ConsultantRecommendation,
            userCart.TotalPrice,
            userCart.CreationDate ?? DateTime.UtcNow,
            cartItems
        );
    }
}
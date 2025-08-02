using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Carts;

namespace Infrastructures.Features.Carts.Queries.GetMyCart;

public class GetMyCartHandler : IRequestHandler<GetMyCartQuery, List<GetMyCartResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimsService _claimsService;

    public GetMyCartHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _claimsService = claimsService;
    }

    public async Task<List<GetMyCartResponse>> Handle(GetMyCartQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
            throw new AppExceptions("Không tìm thấy thông tin người dùng.");

        // Get user with carts and cart items using GetAllAsync with predicate
        var userWithCarts = await _unitOfWork.CustomerUserRepository.GetAllAsync(
            predicate: u => u.Id == currentUserId,
            include: source => source
                .Include(c => c.Carts.Where(cart => !cart.IsDeleted))
                .ThenInclude(cart => cart.CartItems.Where(ci => !ci.IsDeleted))
                .ThenInclude(ci => ci.Product)
                .Include(c => c.Carts.Where(cart => !cart.IsDeleted))
                .ThenInclude(cart => cart.CartItems.Where(ci => !ci.IsDeleted))
                .ThenInclude(ci => ci.ProductItem)
        );

        var user = userWithCarts.FirstOrDefault();
        if (user == null)
            throw new AppExceptions("Không tìm thấy thông tin người dùng.");

        var userCarts = user.Carts;

        return new List<GetMyCartResponse>(
            userCarts.Select(cart => new GetMyCartResponse(
                cart.Id,
                cart.UserId ?? Guid.Empty,
                cart.ConsultantUserId ?? Guid.Empty,
                cart.IsConsultantUserRecommend,
                cart.TotalPrice,
                cart.CreationDate ?? DateTime.UtcNow,
                cart.CartItems.Select(ci => new CartItemResponse(
                    ci.Id,
                    ci.ProductId,
                    ci.ProductItemId,
                    ci.Quantity,
                    ci.Price,
                    ci.TotalPrice,
                    ci.IsSelected,
                    ci.CreationDate ?? DateTime.UtcNow
                )).ToList()
            )).ToList()
        );
    }
}
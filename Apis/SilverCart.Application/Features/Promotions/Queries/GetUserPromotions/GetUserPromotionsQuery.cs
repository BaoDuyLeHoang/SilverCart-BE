using MediatR;
using SilverCart.Application.Services.System;
using SilverCart.Domain.Entities.Promotions;
using Infrastructures.Commons.Exceptions;
using Infrastructures;
using SilverCart.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SilverCart.Application.Features.Promotions.Queries.GetUserPromotions;

public sealed record GetUserPromotionsQuery : IRequest<GetUserPromotionsResponse>;

public record GetUserPromotionsResponse(
    List<UserPromotionItem> Promotions
);

public record UserPromotionItem(
    Guid Id,
    Guid PromotionId,
    string PromotionName,
    string PromotionDescription,
    decimal DiscountAmount,
    DateTime? ExpiryDate,
    bool IsUsed
);

public class GetUserPromotionsQueryHandler : IRequestHandler<GetUserPromotionsQuery, GetUserPromotionsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimsService _claimsService;

    public GetUserPromotionsQueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _claimsService = claimsService;
    }

    public async Task<GetUserPromotionsResponse> Handle(GetUserPromotionsQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
            throw new AppExceptions("Người dùng chưa đăng nhập", 401);

        // Validate user exists using CustomerUserRepository
        var user = await _unitOfWork.CustomerUserRepository.GetByIdAsync(currentUserId);
        if (user == null)
            throw new AppExceptions("Người dùng không tồn tại", 404);

        var userPromotions = await _unitOfWork.UserPromotionRepository.GetAllAsync(
            predicate: up => up.UserId == currentUserId,
            include: up => up.Include(u => u.Promotion)
        );

        var promotionItems = userPromotions.Select(up => new UserPromotionItem(
            up.Id,
            up.PromotionId,
            up.Promotion != null ? up.Promotion.Name : "Khuyến mãi",
            up.Promotion != null ? up.Promotion.Description : "",
            up.Promotion != null ? up.Promotion.Discount : 0,
            up.Promotion != null ? up.Promotion.EndDate : null,
            up.IsUsed
        )).ToList();

        return new GetUserPromotionsResponse(promotionItems);
    }
}
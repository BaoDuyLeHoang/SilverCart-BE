using MediatR;
using SilverCart.Application.Services.System;
using SilverCart.Domain.Entities.Promotions;
using Infrastructures.Commons.Exceptions;
using Infrastructures;
using SilverCart.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SilverCart.Application.Features.Promotions.Queries.GetAvailablePromotions;

public sealed record GetAvailablePromotionsQuery : IRequest<GetAvailablePromotionsResponse>;

public record GetAvailablePromotionsResponse(
    List<AvailablePromotionItem> Promotions
);

public record AvailablePromotionItem(
    Guid Id,
    string Name,
    string Description,
    decimal DiscountAmount,
    DateTime? ExpiryDate,
    bool IsActive
);

public class GetAvailablePromotionsQueryHandler : IRequestHandler<GetAvailablePromotionsQuery, GetAvailablePromotionsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimsService _claimsService;

    public GetAvailablePromotionsQueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _claimsService = claimsService;
    }

    public async Task<GetAvailablePromotionsResponse> Handle(GetAvailablePromotionsQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
            throw new AppExceptions("Người dùng chưa đăng nhập");

        var availablePromotions = await _unitOfWork.PromotionRepository.GetAllAsync(
            predicate: p => p.IsActive && p.EndDate > DateTime.UtcNow
        );

        var promotionItems = availablePromotions.Select(p => new AvailablePromotionItem(
            p.Id,
            p.Name,
            p.Description,
            p.Discount,
            p.EndDate,
            p.IsActive
        )).ToList();

        return new GetAvailablePromotionsResponse(promotionItems);
    }
}
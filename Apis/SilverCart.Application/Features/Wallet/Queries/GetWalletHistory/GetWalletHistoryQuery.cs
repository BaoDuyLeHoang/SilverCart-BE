using MediatR;
using SilverCart.Application.Services.System;
using SilverCart.Domain.Entities.Payments;
using Infrastructures.Commons.Exceptions;
using Infrastructures;
using SilverCart.Application.Interfaces;
using Infrastructures.Commons.Paginations;
using Microsoft.EntityFrameworkCore;

namespace SilverCart.Application.Features.Wallet.Queries.GetWalletHistory;

public sealed record GetWalletHistoryQuery(PagingRequest? PagingRequest) : IRequest<GetWalletHistoryResponse>;

public record GetWalletHistoryResponse(
    List<WalletHistoryItem> History,
    int TotalCount,
    int PageNumber,
    int PageSize
);

public record WalletHistoryItem(
    Guid Id,
    decimal Amount,
    string Description,
    DateTime TransactionDate,
    string TransactionType
);

public class GetWalletHistoryQueryHandler : IRequestHandler<GetWalletHistoryQuery, GetWalletHistoryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimsService _claimsService;

    public GetWalletHistoryQueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _claimsService = claimsService;
    }

    public async Task<GetWalletHistoryResponse> Handle(GetWalletHistoryQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
            throw new AppExceptions("Người dùng chưa đăng nhập");

        // Validate user exists using CustomerUserRepository
        var user = await _unitOfWork.CustomerUserRepository.GetByIdAsync(currentUserId);
        if (user == null)
            throw new AppExceptions("Người dùng không tồn tại");

        var paymentHistories = await _unitOfWork.PaymentHistoryRepository.GetAllAsync(
            predicate: ph => ph.UserId == currentUserId,
            include: ph => ph.Include(p => p.PaymentMethod)
        );

        var historyItems = paymentHistories.Select(ph => new WalletHistoryItem(
            ph.Id,
            (decimal)ph.Amount,
            ph.Note ?? "Giao dịch ví tiền",
            ph.CreationDate ?? DateTime.UtcNow,
            ph.PaymentMethod != null ? ph.PaymentMethod.Name : "Không xác định"
        )).ToList();

        var (page, pageSize, _, _) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var pagedHistory = historyItems
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new GetWalletHistoryResponse(
            pagedHistory,
            historyItems.Count,
            page,
            pageSize
        );
    }
}
using MediatR;
using SilverCart.Application.Services.System;
using SilverCart.Domain.Entities.Payments;
using Infrastructures.Commons.Exceptions;
using Infrastructures;
using SilverCart.Application.Interfaces;

namespace SilverCart.Application.Features.Wallet.Queries.GetWalletBalance;

public sealed record GetWalletBalanceQuery : IRequest<GetWalletBalanceResponse>;

public record GetWalletBalanceResponse(
    Guid WalletId,
    decimal Balance,
    int Points,
    decimal TotalSpent,
    decimal TotalReceived,
    decimal TotalRefunded
);

public class GetWalletBalanceQueryHandler : IRequestHandler<GetWalletBalanceQuery, GetWalletBalanceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimsService _claimsService;

    public GetWalletBalanceQueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _claimsService = claimsService;
    }

    public async Task<GetWalletBalanceResponse> Handle(GetWalletBalanceQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
            throw new AppExceptions("Người dùng chưa đăng nhập");

        // Validate user exists using CustomerUserRepository
        var user = await _unitOfWork.CustomerUserRepository.GetByIdAsync(currentUserId, x => x.Wallet);
        if (user?.Wallet == null)
            throw new AppExceptions("Không tìm thấy ví tiền của người dùng");

        return new GetWalletBalanceResponse(
            user.Wallet.Id,
            user.Wallet.Balance,
            user.Wallet.Points,
            user.Wallet.TotalSpent,
            user.Wallet.TotalReceived,
            user.Wallet.TotalRefunded
        );
    }
}
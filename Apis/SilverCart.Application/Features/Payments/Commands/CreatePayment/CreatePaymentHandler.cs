using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;
using VNPAY.NET;
using VNPAY.NET.Enums;
using VNPAY.NET.Models;
using SilverCart.Application.Utils;
using SilverCart.Domain.Entities.Auth;
using FluentValidation.Validators;
using SilverCart.Domain.Entities.Payments;

namespace Infrastructures.Features.Payments.Commands.CreatePayment;

public sealed record CreatePaymentCommand(
    Guid WalletId,
    double Money,
    Guid PaymentMethodId,
    BankCode BankCode = BankCode.ANY
) : IRequest<string>;

public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentTime _currentTime;
    private readonly IVnpay _vnpay;

    public CreatePaymentHandler(
        IUnitOfWork unitOfWork,
        ICurrentTime currentTime,
        IVnpay vnpay)
    {
        _unitOfWork = unitOfWork;
        _currentTime = currentTime;
        _vnpay = vnpay;
    }

    public async Task<string> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var wallet =
            await _unitOfWork.WalletRepository.GetByIdAsync(request.WalletId, w => w.User, w => w.GuardianUser);
        if (wallet == null)
            throw new KeyNotFoundException($"Ví của người dùng với ID {request.WalletId} không tồn tại");
        var paymentHistory = new PaymentHistory
        {
            Id = Guid.NewGuid(),
            Amount = request.Money,
            PreviousBalance = wallet.Balance,
            NewBalance = wallet.Balance + request.Money,
            PaymentMethodId = request.PaymentMethodId,
            Status = PaymentStatusEnum.Pending
        };
        wallet.PaymentHistories.Add(paymentHistory);

        _unitOfWork.WalletRepository.Update(wallet);
        string description =
            $"Nạp tiền vào ví {wallet.Id}|{paymentHistory.Id} - {request.Money} VND của user {wallet.User?.FullName ?? wallet.GuardianUser?.FullName} - {_currentTime.GetCurrentTime().ToString("dd/MM/yyyy")}";
        paymentHistory.Note = description;
        await _unitOfWork.SaveChangeAsync(cancellationToken);
        string? paymentUrl;
        paymentUrl = GetVNPAYUrl(request, wallet, description);
        if (string.IsNullOrEmpty(paymentUrl))
            throw new Exception("Lỗi khi tạo URL thanh toán");

        return paymentUrl;
    }

    private string GetVNPAYUrl(CreatePaymentCommand request, Wallet wallet, string description)
    {
        var currentTime = _currentTime.GetCurrentTime();
        var paymentRequest = new PaymentRequest
        {
            PaymentId = currentTime.Ticks,
            Money = (double)request.Money * 100, // Convert to smallest currency unit
            Description = description,
            BankCode = request.BankCode,
            CreatedDate = currentTime,
            Currency = Currency.VND,
            Language = DisplayLanguage.Vietnamese
        };

        return _vnpay.GetPaymentUrl(paymentRequest);
    }
}
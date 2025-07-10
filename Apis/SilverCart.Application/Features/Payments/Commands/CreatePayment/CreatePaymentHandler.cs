using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;
using VNPAY.NET;
using VNPAY.NET.Enums;
using VNPAY.NET.Models;

namespace Infrastructures.Features.Payments.Commands.CreatePayment;

public sealed record CreatePaymentCommand(Guid OrderId, PaymentMethodEnum PaymentMethod, BankCode BankCode = BankCode.ANY) : IRequest<string>;

public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentTime _currentTime;
    private readonly IClaimsService _claimsService;
    private readonly IVnpay _vnpay;

    public CreatePaymentHandler(
        IUnitOfWork unitOfWork,
        ICurrentTime currentTime,
        IClaimsService claimsService,
        IVnpay vnpay)
    {
        _unitOfWork = unitOfWork;
        _currentTime = currentTime;
        _claimsService = claimsService;
        _vnpay = vnpay;
    }

    public async Task<string> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId);
        if (order == null)
            throw new KeyNotFoundException($"Order with ID {request.OrderId} not found");

        var cultureInfo = _claimsService.GetUserCultureInfo();
        string description = cultureInfo.Name == "vi-VN"
            ? $"Thanh toán đơn hàng {order.Id} - {order.TotalPrice} VND - {order.CreationDate.Value.ToString("dd/MM/yyyy", cultureInfo)}"
            : $"Payment for order {order.Id} - {order.TotalPrice} VND - {order.CreationDate.Value.ToString("dd/MM/yyyy", cultureInfo)}";

        string? paymentUrl = null;
        switch (request.PaymentMethod)
        {
            case PaymentMethodEnum.VNPAY:
                paymentUrl = GetVNPAYUrl(request, order, description, cultureInfo);
                break;
            case PaymentMethodEnum.MOMO:
                throw new NotImplementedException("MOMO payment is not implemented yet");
            case PaymentMethodEnum.ZALOPAY:
                throw new NotImplementedException("ZALOPAY payment is not implemented yet");
            default:
                throw new ArgumentException($"Unsupported payment method: {request.PaymentMethod}");
        }

        if (string.IsNullOrEmpty(paymentUrl))
            throw new Exception("Failed to create payment URL");

        return paymentUrl;
    }

    private string GetVNPAYUrl(CreatePaymentCommand request, Order order, string description, System.Globalization.CultureInfo cultureInfo)
    {
        var currentTime = _currentTime.GetCurrentTime();
        var paymentRequest = new PaymentRequest
        {
            PaymentId = currentTime.Ticks,
            Money = (double)order.TotalPrice * 100, // Convert to smallest currency unit
            Description = description,
            BankCode = request.BankCode,
            CreatedDate = currentTime,
            Currency = Currency.VND,
            Language = cultureInfo.Name == "vi-VN" ? DisplayLanguage.Vietnamese : DisplayLanguage.English
        };

        return _vnpay.GetPaymentUrl(paymentRequest);
    }
}

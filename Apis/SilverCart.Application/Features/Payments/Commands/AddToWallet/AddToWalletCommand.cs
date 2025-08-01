using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Enums;
using VNPAY.NET;
using VNPAY.NET.Models;

namespace Infrastructures.Features.Payments.Commands.AddToWallet;

public sealed record AddToWalletCommand(PaymentResponse PaymentResponse) : IRequest<AddToWalletResponse>;

public record AddToWalletResponse(
    Guid WalletId,
    int PreviousBalance,
    int NewBalance,
    double AmountAdded,
    bool IsSuccess,
    string Message
);

public class AddToWalletHandler : IRequestHandler<AddToWalletCommand, AddToWalletResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentTime _currentTime;
    public AddToWalletHandler(IUnitOfWork unitOfWork, ICurrentTime currentTime)
    {
        _unitOfWork = unitOfWork;
        _currentTime = currentTime;
    }

    public async Task<AddToWalletResponse> Handle(AddToWalletCommand request, CancellationToken cancellationToken)
    {
        // Extract OrderId and Amount from PaymentResponse
        // TODO: Check VNPAY.NET PaymentResponse properties and adjust accordingly
        var walletId = request.PaymentResponse.Description.Split(" ")[4].Split("|")[0];//Nạp tiền vào ví {wallet.Id}|{paymentHistory.Id}
        var paymentHistoryId = request.PaymentResponse.Description.Split(" ")[4].Split("|")[1];//Nạp tiền vào ví {wallet.Id}|{paymentHistory.Id}

        // Find wallet by OrderId (assuming OrderId is stored as a reference)
        // You might need to adjust this logic based on how you store the wallet reference
        var wallet = await _unitOfWork.WalletRepository.GetByIdAsync(Guid.Parse(walletId));
        var paymentHistory = await _unitOfWork.PaymentHistoryRepository.GetByIdAsync(Guid.Parse(paymentHistoryId));
        if (wallet == null)
        {
            throw new AppExceptions("Không tìm thấy ví với Id: " + walletId, 404);
        }
        var (isSuccess, message) = ValidateCode(request.PaymentResponse.Code.ToString());

        if (!isSuccess)
        {
            paymentHistory.Status = PaymentStatusEnum.Failed;
            _unitOfWork.PaymentHistoryRepository.Update(paymentHistory);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return new AddToWalletResponse(
                wallet.Id,
                wallet.Balance,
                wallet.Balance,
                paymentHistory.Amount,
                false,
                message
            );
        }
        var previousBalance = wallet.Balance;
        var amountToAdd = paymentHistory.Amount; // Convert from smallest currency unit to VND
        var points = paymentHistory.Points;
        // Update wallet balance

        wallet.Balance += (int)amountToAdd;
        wallet.TotalReceived += (int)amountToAdd;
        if (points != null)
            wallet.Points += (int)points;
        paymentHistory.Status = PaymentStatusEnum.Paid;

        // Save changes - only update wallet for now
        _unitOfWork.WalletRepository.Update(wallet);
        _unitOfWork.PaymentHistoryRepository.Update(paymentHistory);
        await _unitOfWork.SaveChangeAsync(cancellationToken);

        return new AddToWalletResponse(
            wallet.Id,
            previousBalance,
            wallet.Balance,
            amountToAdd,
            true,
            message
        );
    }

    private (bool, string message) ValidateCode(string code)
    {

        switch (code)
        {
            case "00":
                return (true, "Giao dịch thành công");
            case "07":
                return (false, "Trừ tiền thành công. Giao dịch bị nghi ngờ(liên quan tới lừa đảo, giao dịch bất thường).");
            case "09":
                return (false, "Giao dịch không thành công do: Thẻ/Tài khoản của khách hàng chưa đăng ký dịch vụ InternetBanking tại ngân hàng.");
            case "10":
                return (false, "Giao dịch không thành công do: Khách hàng xác thực thông tin thẻ/tài khoản không đúng quá 3 lần");
            case "11":
                return (false, "Giao dịch không thành công do: Đã hết hạn chờ thanh toán. Xin quý khách vui lòng thực hiện lại giao dịch.");
            case "12":
                return (false, "Giao dịch không thành công do: Thẻ/Tài khoản của khách hàng bị khóa.");
            case "13":
                return (false, "Giao dịch không thành công do Quý khách nhập sai mật khẩu xác thực giao dịch(OTP).Xin quý khách vui lòng thực hiện lại giao dịch.");
            case "24":
                return (false, "Giao dịch không thành công do: Khách hàng hủy giao dịch");
            case "51":
                return (false, "Giao dịch không thành công do: Tài khoản của quý khách không đủ số dư để thực hiện giao dịch.");
            case "65":
                return (false, "Giao dịch không thành công do: Tài khoản của Quý khách đã vượt quá hạn mức giao dịch trong ngày.");
            case "75":
                return (false, "Ngân hàng thanh toán đang bảo trì.");
            case "79":
                return (false, "Giao dịch không thành công do: KH nhập sai mật khẩu thanh toán quá số lần quy định. Xin quý khách vui lòng thực hiện lại giao dịch");
            default:
                return (false, "Giao dịch không thành công");
        }
    }
}
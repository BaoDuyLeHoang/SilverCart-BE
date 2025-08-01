using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures;

public sealed record GetPaymentHistoryDetailsQuery(Guid Id) : IRequest<GetPaymentHistoryDetailsResponse>;
public record GetPaymentHistoryDetailsResponse(Guid Id, string PaymentMethodName, double Amount, double PreviousBalance, double NewBalance, string Note, double? Points, string Promotion, DateTime? CreationDate, string Status, string Customer);
public class GetPaymentDetailsHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPaymentHistoryDetailsQuery, GetPaymentHistoryDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public async Task<GetPaymentHistoryDetailsResponse> Handle(GetPaymentHistoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var paymentHistory = await _unitOfWork.PaymentHistoryRepository.GetByIdAsync(request.Id, 
            ph => ph.PaymentMethod);
        if (paymentHistory == null)
        {
            throw new KeyNotFoundException($"Payment history with ID {request.Id} not found.");
        }
        return new GetPaymentHistoryDetailsResponse(
            paymentHistory.Id,
            paymentHistory.PaymentMethod?.Name ?? "Unknown",
            paymentHistory.Amount,
            paymentHistory.PreviousBalance,
            paymentHistory.NewBalance,
            paymentHistory.Note,
            paymentHistory.Points,
            paymentHistory.Promotion.Name ?? "None",
            paymentHistory.CreationDate,
            paymentHistory.Status.ToString(),
            paymentHistory.CustomerUser.FullName ?? "Unknown"
            );
    }
}


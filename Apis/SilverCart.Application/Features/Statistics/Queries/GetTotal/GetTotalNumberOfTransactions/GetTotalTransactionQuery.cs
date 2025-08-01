using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalTransactions
{
    public sealed record GetTotalNumberOfTransactionsQuery(TimeFrame TimeFrame, DateTime? ChosenDate = null) : IRequest<List<GetTotalNumberOfTransactionsResponse>>;

    public record GetTotalNumberOfTransactionsResponse(string TimePeriod, int TotalTransactions);

    public class GetTotalNumberOfTransactionsQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetTotalNumberOfTransactionsQuery, List<GetTotalNumberOfTransactionsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<List<GetTotalNumberOfTransactionsResponse>> Handle(GetTotalNumberOfTransactionsQuery request, CancellationToken cancellationToken)
        {
            var chosenDate = DateTime.SpecifyKind(request.ChosenDate ?? DateTime.UtcNow, DateTimeKind.Utc);

            DateTime startDate, endDate;

            switch (request.TimeFrame)
            {
                case TimeFrame.Week:
                    startDate = chosenDate.AddDays(-(int)chosenDate.DayOfWeek + (int)DayOfWeek.Monday).Date;
                    endDate = startDate.AddDays(7);
                    break;

                case TimeFrame.Month:
                    startDate = new DateTime(chosenDate.Year, chosenDate.Month, 1, 0, 0, 0, DateTimeKind.Utc);
                    endDate = startDate.AddMonths(1);
                    break;

                case TimeFrame.Year:
                    startDate = new DateTime(chosenDate.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    endDate = startDate.AddYears(1);
                    break;

                default:
                    throw new AppExceptions("TimeFrame không hợp lệ");
            }

            var payments = await _unitOfWork.PaymentHistoryRepository.GetAllAsync();
            var paidTransactions = payments
                .Where(p => p.Status == PaymentStatusEnum.Paid && p.CreationDate >= startDate && p.CreationDate < endDate)
                .ToList();

            var periods = request.TimeFrame switch
            {
                TimeFrame.Week or TimeFrame.Month => Enumerable.Range(0, (endDate - startDate).Days)
                    .Select(offset => startDate.AddDays(offset).Date.ToUniversalTime()),
                TimeFrame.Year => Enumerable.Range(0, 12)
                    .Select(month => new DateTime(startDate.Year, month + 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                _ => throw new AppExceptions("Không tìm thấy TimeFrame")
            };

            var totalCount = paidTransactions.Count();

            var timePeriodLabel = request.TimeFrame switch
            {
                TimeFrame.Week => $"{startDate:yyyy-MM-dd} to {endDate.AddDays(1):yyyy-MM-dd}",
                TimeFrame.Month => $"{startDate:yyyy-MM-dd} to {endDate.AddMonths(1):yyyy-MM-dd}",
                TimeFrame.Year => $"{startDate:yyyy} to to {endDate.AddYears(1):yyyy-MM-dd}",
                _ => throw new AppExceptions("Không tìm thấy TimeFrame")
            };

            var statistics = new List<GetTotalNumberOfTransactionsResponse>
{
    new(timePeriodLabel, totalCount)
};
            return statistics;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalRevenues
{
    public sealed record GetTotalRevenuesCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null) : IRequest<List<GetTotalRevenuesQueryResponse>>;
    public record GetTotalRevenuesQueryResponse(string TimePeriod, decimal TotalRevenues);
    public class GetTotalRevenuesQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTotalRevenuesCommand, List<GetTotalRevenuesQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<List<GetTotalRevenuesQueryResponse>> Handle(GetTotalRevenuesCommand request, CancellationToken cancellationToken)
        {
            var chosenDate = request.ChosenDate ?? DateTime.UtcNow;
            DateTime startDate, endDate;

            var orders = await _unitOfWork.OrderRepository.GetAllAsync();
            switch (request.TimeFrame)
            {
                case TimeFrame.Week:
                    startDate = chosenDate.AddDays(DayOfWeek.Monday - chosenDate.DayOfWeek);
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

            var totalRevenues = orders.Where(p => p.CreationDate >= startDate && p.CreationDate < endDate).Sum(p => p.TotalPrice);
            var periods = request.TimeFrame switch
            {
                TimeFrame.Week or TimeFrame.Month => Enumerable.Range(0, (endDate - startDate).Days)
                    .Select(offset => startDate.AddDays(offset).Date.ToUniversalTime()),
                TimeFrame.Year => Enumerable.Range(0, 12)
                    .Select(month => new DateTime(startDate.Year, month + 1, 1, 0, 0, 0, DateTimeKind.Utc)),
                _ => throw new AppExceptions("Không tìm thấy TimeFrame")
            };
            var statistics = request.TimeFrame switch
            {
                TimeFrame.Week or TimeFrame.Month => periods.Select(period => new GetTotalRevenuesQueryResponse(period.ToString("yyyy-MM-dd"), totalRevenues)).ToList(),
                TimeFrame.Year => periods.Select(period => new GetTotalRevenuesQueryResponse(period.ToString("yyyy-M"), totalRevenues)).ToList(),
                _ => throw new AppExceptions("Không tìm thấy TimeFrame")
            };
            return statistics;
        }
    }
}
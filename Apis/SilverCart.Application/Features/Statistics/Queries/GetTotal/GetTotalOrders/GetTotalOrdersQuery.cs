using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalOrders
{
    public sealed record GetTotalOrdersCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null) : IRequest<List<GetTotalOrdersQueryResponse>>;
    public record GetTotalOrdersQueryResponse(string TimePeriod, int TotalOrders);
    public class GetTotalOrdersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTotalOrdersCommand, List<GetTotalOrdersQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<List<GetTotalOrdersQueryResponse>> Handle(GetTotalOrdersCommand request, CancellationToken cancellationToken)
        {
            var chosenDate = request.ChosenDate ?? DateTime.UtcNow.AddHours(7);
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

            var totalOrders = orders.Where(o => o.CreationDate >= startDate && o.CreationDate < endDate).Count();
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
                TimeFrame.Week or TimeFrame.Month => periods.Select(p => new GetTotalOrdersQueryResponse(p.ToString("yyyy-MM-dd"), orders.Count(o => o.CreationDate.HasValue && o.CreationDate.Value.Date == p.Date))).ToList(),
                TimeFrame.Year => periods.Select(p => new GetTotalOrdersQueryResponse(p.ToString("yyyy-M"), orders.Count(o => o.CreationDate.HasValue && o.CreationDate.Value.Month == p.Month && o.CreationDate.Value.Year == p.Year))).ToList(),
                _ => throw new AppExceptions("Không tìm thấy TimeFrame")
            };

            return statistics;
        }
    }
}

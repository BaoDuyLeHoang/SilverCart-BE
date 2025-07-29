using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalCustomers
{
    public sealed record GetTotalCustomerCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null) : IRequest<List<GetTotalCustomerQueryResponse>>;
    public record GetTotalCustomerQueryResponse(string TimePeriod, int TotalCustomers);
    public class GetTotalCustomerQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTotalCustomerCommand, List<GetTotalCustomerQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<List<GetTotalCustomerQueryResponse>> Handle(GetTotalCustomerCommand request, CancellationToken cancellationToken)
        {
            var chosenDate = request.ChosenDate ?? DateTime.UtcNow;
            DateTime startDate, endDate;
            //Customer = Guardian User + DependentUser
            var guardianUsers = await _unitOfWork.GuardianUserRepository.GetAllAsync();
            var dependentUsers = await _unitOfWork.DependentUserRepository.GetAllAsync();

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
            var totalGuardianUsers = guardianUsers.Where(p => p.CreationDate >= startDate && p.CreationDate < endDate).Count();
            var totalDependentUsers = dependentUsers.Where(p => p.CreationDate >= startDate && p.CreationDate < endDate).Count();
            var totalCustomers = totalGuardianUsers + totalDependentUsers;
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
                TimeFrame.Week or TimeFrame.Month => periods.Select(period => new GetTotalCustomerQueryResponse(period.ToString("yyyy-MM-dd"), totalCustomers)).ToList(),
                TimeFrame.Year => periods.Select(period => new GetTotalCustomerQueryResponse(period.ToString("yyyy-M"), totalCustomers)).ToList(),
                _ => throw new AppExceptions("Không tìm thấy TimeFrame")
            };
            return statistics;
        }
    }
}
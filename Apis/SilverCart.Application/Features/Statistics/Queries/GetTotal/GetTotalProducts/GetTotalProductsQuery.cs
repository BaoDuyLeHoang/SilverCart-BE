using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalProducts
{
    public sealed record GetTotalProductsCommand(TimeFrame TimeFrame, DateTime? ChosenDate = null) : IRequest<List<GetTotalProductsQueryResponse>>;
    public record GetTotalProductsQueryResponse(string TimePeriod, int TotalProducts);
    public class GetTotalProductsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTotalProductsCommand, List<GetTotalProductsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<List<GetTotalProductsQueryResponse>> Handle(GetTotalProductsCommand request, CancellationToken cancellationToken)
        {
            var chosenDate = request.ChosenDate ?? DateTime.UtcNow;
            DateTime startDate, endDate;

            var products = await _unitOfWork.ProductItemRepository.GetAllAsync();
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

            var totalProducts = products.Where(p => p.CreationDate >= startDate && p.CreationDate < endDate).Count();
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
                TimeFrame.Week or TimeFrame.Month => periods.Select(period => new GetTotalProductsQueryResponse(period.ToString("yyyy-MM-dd"), products.Count(product => product.CreationDate.HasValue && product.CreationDate.Value.Date == period))).ToList(),
                TimeFrame.Year => periods.Select(period => new GetTotalProductsQueryResponse(period.ToString("yyyy-M"), products.Count(product => product.CreationDate.HasValue && product.CreationDate.Value.Month == period.Month && product.CreationDate.Value.Year == period.Year))).ToList(),
                _ => throw new AppExceptions("Không tìm thấy TimeFrame")
            };

            return statistics;
        }
    }
}
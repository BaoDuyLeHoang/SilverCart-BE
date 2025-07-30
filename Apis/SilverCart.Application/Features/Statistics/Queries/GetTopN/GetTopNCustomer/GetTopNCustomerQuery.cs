using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures.Features.Statistics.Queries.GetTopN.GetTopNCustomer
{
    public sealed record GetTopNCustomerCommand(int TopN) : IRequest<GetTopNCustomerQueryResponse>;
    public record GetTopNCustomerQueryResponse(List<GetTopNCustomerItemsResponse> CustomerItems);
    public record GetTopNCustomerItemsResponse(string CustomerName, int TotalOrders);
    public class GetTopNCustomerQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTopNCustomerCommand, GetTopNCustomerQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<GetTopNCustomerQueryResponse> Handle(GetTopNCustomerCommand request, CancellationToken cancellationToken)
        {
            var currentMonthStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var lastMonthStart = currentMonthStart.AddMonths(-1);
            var lastMonthEnd = currentMonthStart.AddDays(-1);

            var orders = await _unitOfWork.OrderRepository.GetAllAsync(
                predicate: p => p.CreationDate >= currentMonthStart && p.CreationDate <= DateTime.UtcNow,
                include: p => p.Include(p => p.Guardian).Include(p => p.DependentUser)
            );

            // Process data in memory to avoid set operation after client projection
            var customerStats = new Dictionary<string, int>();

            foreach (var order in orders)
            {
                if (order.Guardian != null)
                {
                    var guardianName = order.Guardian.FullName;
                    if (customerStats.ContainsKey(guardianName))
                    {
                        customerStats[guardianName]++;
                    }
                    else
                    {
                        customerStats[guardianName] = 1;
                    }
                }

                if (order.DependentUser != null)
                {
                    var dependentName = order.DependentUser.FullName;
                    if (customerStats.ContainsKey(dependentName))
                    {
                        customerStats[dependentName]++;
                    }
                    else
                    {
                        customerStats[dependentName] = 1;
                    }
                }
            }

            // Convert to response format and get top N
            var topNCustomerItems = customerStats
                .Select(kvp => new GetTopNCustomerItemsResponse(kvp.Key, kvp.Value))
                .OrderByDescending(p => p.TotalOrders)
                .Take(request.TopN)
                .ToList();

            return new GetTopNCustomerQueryResponse(topNCustomerItems);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Features.Statistics.Queries.GetTopN.GetTopNProduct
{
    public sealed record GetTopNProductCommand(int TopN) : IRequest<GetTopNProductQueryResponse>;
    public record GetTopNProductQueryResponse(List<GetTopNProductItemsResponse> ProductItems);
    public record GetTopNProductItemsResponse(string ProductName, int TotalQuantity, decimal TotalRevenue);
    public class GetTopNProductQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetTopNProductCommand, GetTopNProductQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<GetTopNProductQueryResponse> Handle(GetTopNProductCommand request, CancellationToken cancellationToken)
        {
            var currentMonthStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var lastMonthStart = currentMonthStart.AddMonths(-1);
            var lastMonthEnd = currentMonthStart.AddDays(-1);

            // Step 1: Get orders with all related data
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(
                predicate: p => p.CreationDate >= currentMonthStart && p.CreationDate <= DateTime.UtcNow,
                include: p => p.Include(p => p.OrderDetails).ThenInclude(p => p.ProductItem).ThenInclude(p => p.Product)
            );

            // Step 2: Process data in memory to avoid complex LINQ translation
            var productStats = new Dictionary<string, (int TotalQuantity, decimal TotalRevenue)>();

            foreach (var order in orders)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    if (orderDetail.ProductItem?.Product != null)
                    {
                        var productName = orderDetail.ProductItem.Product.Name;
                        var quantity = orderDetail.Quantity;
                        var revenue = orderDetail.ProductItem.OriginalPrice * quantity;

                        if (productStats.ContainsKey(productName))
                        {
                            var current = productStats[productName];
                            productStats[productName] = (current.TotalQuantity + quantity, current.TotalRevenue + revenue);
                        }
                        else
                        {
                            productStats[productName] = (quantity, revenue);
                        }
                    }
                }
            }

            // Step 3: Convert to response format and get top N
            var topNProductItems = productStats
                .Select(kvp => new GetTopNProductItemsResponse(
                    kvp.Key,
                    kvp.Value.TotalQuantity,
                    kvp.Value.TotalRevenue
                ))
                .OrderByDescending(p => p.TotalQuantity)
                .Take(request.TopN)
                .ToList();

            return new GetTopNProductQueryResponse(topNProductItems);
        }
    }
}

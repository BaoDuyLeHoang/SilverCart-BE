using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Statistics.Queries.GetCurrentStatistic
{
    public sealed record GetCurrentStatisticCommand : IRequest<GetCurrentStatisticQueryResponse>;
    public record GetCurrentStatisticQueryResponse(GetRevenueStatisticResponse RevenueStatisticResponse, GetOrderStatisticResponse OrderStatisticResponse, GetUserStatisticResponse UserStatisticResponse);
    public record GetRevenueStatisticResponse(decimal TotalRevenue, decimal TotalRevenueLastMonth, decimal PercentageCompareLastMonth);
    public record GetOrderStatisticResponse(int TotalOrders, int TotalOrdersLastMonth, decimal PercentageCompareLastMonth);
    public record GetUserStatisticResponse(int TotalUsers, int TotalUsersLastMonth, decimal PercentageCompareLastMonth);
    public class GetCurrentStatisticQuery(IUnitOfWork unitOfWork, IClaimsService claimsService, UserManager<BaseUser> userManager) : IRequestHandler<GetCurrentStatisticCommand, GetCurrentStatisticQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        private readonly UserManager<BaseUser> _userManager = userManager;
        public async Task<GetCurrentStatisticQueryResponse> Handle(GetCurrentStatisticCommand request, CancellationToken cancellationToken)
        {
            // var currentUserRole = _claimsService.CurrentRole;
            // if (currentUserRole != "Administrator" && currentUserRole != "Consultant")
            // {
            //     throw new UnauthorizedAccessException("You do not have permission to access this resource.");
            // }
            var currentMonthStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);
            var lastMonthStart = currentMonthStart.AddMonths(-1);
            var lastMonthEnd = currentMonthStart.AddDays(-1);

            var totalRevenue = await _unitOfWork.OrderRepository.GetAllAsync(
                predicate: p => p.PaymentStatus.PaymentStatus == PaymentStatusEnum.Paid,
                include: p => p.Include(p => p.OrderDetails).ThenInclude(p => p.ProductItem).ThenInclude(p => p.Product)
            );

            var totalRevenueAmount = totalRevenue.Where(p => p.CreationDate >= currentMonthStart && p.CreationDate <= DateTime.UtcNow).Sum(p => p.OrderDetails.Sum(o => o.ProductItem.OriginalPrice * o.Quantity));
            var totalRevenueAmountLastMonth = totalRevenue.Where(p => p.CreationDate >= lastMonthStart && p.CreationDate <= lastMonthEnd).Sum(p => p.OrderDetails.Sum(o => o.ProductItem.OriginalPrice * o.Quantity));
            var percentageRevenueCompareLastMonth = totalRevenueAmountLastMonth > 0 ? totalRevenueAmount / totalRevenueAmountLastMonth : 0;

            var totalOrders = await _unitOfWork.OrderRepository.GetAllAsync(
                predicate: p => p.CreationDate >= currentMonthStart && p.CreationDate <= DateTime.UtcNow,
                include: p => p.Include(p => p.OrderDetails)
            );
            var totalOrdersAmount = totalOrders.Where(p => p.CreationDate >= currentMonthStart && p.CreationDate <= DateTime.UtcNow).Sum(p => p.OrderDetails.Sum(o => o.ProductItem.OriginalPrice * o.Quantity));
            var totalOrdersAmountLastMonth = totalOrders.Where(p => p.CreationDate >= lastMonthStart && p.CreationDate <= lastMonthEnd).Sum(p => p.OrderDetails.Sum(o => o.ProductItem.OriginalPrice * o.Quantity));
            var percentageOrdersCompareLastMonth = totalOrdersAmountLastMonth > 0 ? totalOrdersAmount / totalOrdersAmountLastMonth : 0;

            var totalUsers = await _unitOfWork.UserRepository.GetAllAsync(
                predicate: p => p.CreationDate >= currentMonthStart && p.CreationDate <= DateTime.UtcNow
            );
            var totalUsersAmount = totalUsers.Where(p => p.CreationDate >= currentMonthStart && p.CreationDate <= DateTime.UtcNow).Count();
            var totalUsersAmountLastMonth = totalUsers.Where(p => p.CreationDate >= lastMonthStart && p.CreationDate <= lastMonthEnd).Count();
            var percentageUsersCompareLastMonth = totalUsersAmountLastMonth > 0 ? (decimal)totalUsersAmount / totalUsersAmountLastMonth : 0;

            return new GetCurrentStatisticQueryResponse(
                new GetRevenueStatisticResponse(totalRevenueAmount, totalRevenueAmountLastMonth, percentageRevenueCompareLastMonth),
                new GetOrderStatisticResponse((int)totalOrdersAmount, (int)totalOrdersAmountLastMonth, percentageOrdersCompareLastMonth),
                new GetUserStatisticResponse(totalUsersAmount, totalUsersAmountLastMonth, percentageUsersCompareLastMonth)
            );
        }
    }
}

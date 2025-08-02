using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructures.Commons.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Orders.Queries.GetOrderHistory;
public sealed record GetOrderHistoryOfDependentUserCommand(Guid DependentUserId) : IRequest<List<OrderHistoryResponse>>;
public record OrderHistoryResponse(Guid OrderId, DateTime OrderDate, decimal TotalAmount, string OrderStatus, List<OrderItemResponse> Items);
public record OrderItemResponse(Guid ProductId, string ProductName, int Quantity, decimal Price);
public class GetOrderHistoryOfDependentUserQuery(IUnitOfWork unitOfWork) : IRequestHandler<GetOrderHistoryOfDependentUserCommand, List<OrderHistoryResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<List<OrderHistoryResponse>> Handle(GetOrderHistoryOfDependentUserCommand request, CancellationToken cancellationToken)
    {
        // Validate user exists using CustomerUserRepository
        var user = await _unitOfWork.CustomerUserRepository.GetByIdAsync(request.DependentUserId);
        if (user == null)
            throw new AppExceptions($"Không tìm thấy người dùng với ID {request.DependentUserId}");

        var orders = await _unitOfWork.OrderRepository.GetAllAsync(
            predicate: o => o.OrderedUserId == request.DependentUserId,
            include: source => source.Include(o => o.OrderDetails)
                .ThenInclude(od => od.ProductItem)
                    .ThenInclude(pi => pi.ProductImages)
        );

        return orders.Select(order => new OrderHistoryResponse(
            order.Id,
            order.CreationDate ?? DateTime.UtcNow,
            order.TotalPrice,
            order.OrderStatus.ToString(),
            order.OrderDetails.Select(detail => new OrderItemResponse(
                detail.ProductItem.Product.Id,
                detail.ProductItem.Product.Name,
                detail.Quantity,
                detail.Price
            )).ToList()
        )).ToList();
    }
}

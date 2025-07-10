using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public Task<List<OrderHistoryResponse>> Handle(GetOrderHistoryOfDependentUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        var orderList = _unitOfWork.OrderRepository.GetAllAsync(
            predicate: o => o.DependentUserID == request.DependentUserId,
            include: source => source
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.ProductItem)
                        .ThenInclude(pi => pi.Variant)
                            .ThenInclude(v => v.Product)
            );
    }
}

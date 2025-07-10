using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderToStoreConfirm
{
    public sealed record ChangeOrderToStoreConfirmCommand(Guid OrderId) : IRequest<Guid>;
    public class ChangeOrderToStoreConfirmHandler : IRequestHandler<ChangeOrderToStoreConfirmCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChangeOrderToStoreConfirmHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(ChangeOrderToStoreConfirmCommand request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(
                predicate: o => o.Id == request.OrderId,
                include: src => src.Include(o => o.OrderDetails)
                );

            var order = orders.FirstOrDefault();

            if (order == null)
            {
                throw new ArgumentException($"Order with ID {request.OrderId} not found");
            }
            order.OrderStatus = OrderStatusEnums.StoreConfirmed;
            _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.SaveChangeAsync();
            return order.Id;
        }
    }
}

using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStatusToShip
{
    public sealed record class ChangeOrderItemsStatusToShipCommand(Guid OrderId, Guid OrderItemId) : IRequest<Guid>;
    public class ChangeOrderItemsStatusToShipHandler(IUnitOfWork unitOfWork) : IRequestHandler<ChangeOrderItemsStatusToShipCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Guid> Handle(ChangeOrderItemsStatusToShipCommand request, CancellationToken cancellationToken)
        {
            var existedOrder = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId);
            if (existedOrder == null)
                throw new AppExceptions("Order not found");
            var existedOrderItem = await _unitOfWork.OrderItemRepository.GetByIdAsync(request.OrderItemId);
            if (existedOrderItem == null)
                throw new AppExceptions("Order item not found");
            if (existedOrderItem.Status != OrderItemStatusEnums.ConfirmedByStore)
                throw new AppExceptions("Order item is not confirm by store");
            existedOrderItem.Status = OrderItemStatusEnums.Shipping;
            _unitOfWork.OrderItemRepository.Update(existedOrderItem);
            await _unitOfWork.SaveChangeAsync();
            if (existedOrder.OrderItems.All(x => x.Status == OrderItemStatusEnums.Shipping))
            {
                existedOrder.OrderStatus = OrderStatusEnums.Shipping;
                _unitOfWork.OrderRepository.Update(existedOrder);
                await _unitOfWork.SaveChangeAsync();
            }
            return existedOrderItem.Id;
        }
    }
}

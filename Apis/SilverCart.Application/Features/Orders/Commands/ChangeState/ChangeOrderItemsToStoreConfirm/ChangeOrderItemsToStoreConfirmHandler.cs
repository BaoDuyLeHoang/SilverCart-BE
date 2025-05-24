using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsToStoreConfirm
{
    public sealed record ChangeOrderItemsToStoreConfirmCommand(Guid OrderId, Guid OrderItemId) : IRequest<bool>;
    public class ChangeOrderItemsToStoreConfirmHandler(IUnitOfWork unitOfWork) : IRequestHandler<ChangeOrderItemsToStoreConfirmCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<bool> Handle(ChangeOrderItemsToStoreConfirmCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId);
            if (order == null)
                throw new AppExceptions("Order not found");

            var orderItem = await _unitOfWork.OrderItemRepository.GetByIdAsync(request.OrderItemId);
            if (orderItem == null)
                throw new AppExceptions("Order item not found");
            if (orderItem.Status != OrderItemStatusEnums.ConfirmedByGuardian)
                throw new AppExceptions("Order item is not pending");

            orderItem.Status = OrderItemStatusEnums.ConfirmedByStore;
            _unitOfWork.OrderItemRepository.Update(orderItem);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
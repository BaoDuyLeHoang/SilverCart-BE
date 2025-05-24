using System;
using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStateGuardianConfirm;

public sealed record ChangeOrderItemsStateProductOfGuardianCommand(Guid OrderId, Guid OrderItemId) : IRequest<bool>;
public class ChangeOrderItemsStateProductOfGuardian(IUnitOfWork unitOfWork) : IRequestHandler<ChangeOrderItemsStateProductOfGuardianCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<bool> Handle(ChangeOrderItemsStateProductOfGuardianCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId);
        if (order == null)
            throw new AppExceptions("Order not found");
        if (order.OrderStatus != OrderStatusEnums.Pending)
            throw new AppExceptions("Order is not pending");

        var orderItem = await _unitOfWork.OrderItemRepository.GetByIdAsync(request.OrderItemId);
        if (orderItem == null)
            throw new AppExceptions("Order item not found");
        if (orderItem.Status != OrderItemStatusEnums.Pending)
            throw new AppExceptions("Order item is not pending");
        orderItem.Status = OrderItemStatusEnums.ConfirmedByGuardian;

        _unitOfWork.OrderItemRepository.Update(orderItem);
        await _unitOfWork.SaveChangeAsync();

        if (order.OrderItems.All(x => x.Status == OrderItemStatusEnums.ConfirmedByGuardian))
        {
            order.OrderStatus = OrderStatusEnums.GuardianConfirmed;
            _unitOfWork.OrderRepository.Update(order);
        }
        await _unitOfWork.SaveChangeAsync();
        return true;
    }
}

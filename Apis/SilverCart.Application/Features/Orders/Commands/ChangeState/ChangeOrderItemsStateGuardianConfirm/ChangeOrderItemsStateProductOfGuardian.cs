using System;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStateGuardianConfirm;

public sealed record ChangeOrderItemsStateProductOfGuardianCommand(Guid OrderId, Guid OrderDetailId) : IRequest<Guid>;
public class ChangeOrderItemsStateProductOfGuardian(IUnitOfWork unitOfWork) : IRequestHandler<ChangeOrderItemsStateProductOfGuardianCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Guid> Handle(ChangeOrderItemsStateProductOfGuardianCommand request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync(
            predicate: x => x.Id == request.OrderId,
            include: x => x.Include(x => x.OrderDetails)
                            .ThenInclude(x => x.ProductItem));
        var order = await orders.FirstOrDefaultAsync();

        var orderDetails = order.OrderDetails.FirstOrDefault(x => x.Order.Id == request.OrderDetailId);
        if (orderDetails == null)
        {
            throw new AppExceptions("Order detail not found");
        }
        if (orderDetails.OrderItemStatus != OrderItemStatusEnums.Pending)
        {
            throw new AppExceptions("Order item is not in pending state");
        }
        orderDetails.OrderItemStatus = OrderItemStatusEnums.ConfirmedByGuardian;
        _unitOfWork.OrderDetailsRepository.Update(orderDetails);
        //await _unitOfWork.SaveChangeAsync();

        if (order.OrderDetails.All(x => x.OrderItemStatus == OrderItemStatusEnums.ConfirmedByGuardian))
        {
            order.OrderStatus = OrderStatusEnum.GuardianConfirmed;
            _unitOfWork.OrderRepository.Update(order);
        }
        await _unitOfWork.SaveChangeAsync();
        return order.Id;
    }
}

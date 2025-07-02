using System;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStateGuardianConfirm;

public sealed record ChangeOrderItemsStateProductOfGuardianCommand(Guid OrderId, Guid StoreOrderId, Guid StoreProductItemOrderId) : IRequest<Guid>;
public class ChangeOrderItemsStateProductOfGuardian(IUnitOfWork unitOfWork) : IRequestHandler<ChangeOrderItemsStateProductOfGuardianCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Guid> Handle(ChangeOrderItemsStateProductOfGuardianCommand request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWork.OrderRepository.GetAllAsync(
            predicate: x => x.Id == request.OrderId,
            include: x => x.Include(x => x.StoreOrders)
                            .ThenInclude(x => x.StoreProductItemsOrders)
                            .ThenInclude(x => x.StoreProductItem)
                            .ThenInclude(x => x.ProductItem));
        var order = await orders.FirstOrDefaultAsync();

        var storeOrder = order.StoreOrders.FirstOrDefault(x => x.Id == request.StoreOrderId);
        if (storeOrder == null)
        {
            throw new AppExceptions("Store order not found");
        }
        var storeProductItemOrder = storeOrder.StoreProductItemsOrders.FirstOrDefault(x => x.Id == request.StoreProductItemOrderId);
        if (storeProductItemOrder == null)
        {
            throw new AppExceptions("Store product item order not found");
        }
        storeProductItemOrder.Status = StoreProductItemsOrderStatus.ConfirmedByGuardian;
        _unitOfWork.StoreProductItemOrderRepository.Update(storeProductItemOrder);
        await _unitOfWork.SaveChangeAsync();
        if (storeOrder.StoreProductItemsOrders.All(x => x.Status == StoreProductItemsOrderStatus.ConfirmedByGuardian || x.Status == StoreProductItemsOrderStatus.Processing || x.Status == StoreProductItemsOrderStatus.Cancelled))
        {
            storeOrder.Status = StoreOrderStatus.Pending;
            _unitOfWork.StoreOrderRepository.Update(storeOrder);
        }

        await _unitOfWork.SaveChangeAsync();
        return order.Id;
    }
}

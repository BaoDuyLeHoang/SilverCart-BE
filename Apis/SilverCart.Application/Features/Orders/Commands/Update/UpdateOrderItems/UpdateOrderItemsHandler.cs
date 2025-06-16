using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Orders.Commands.Update.UpdateOrderItems
{
    public sealed record UpdateOrderItemsCommand(
        Guid OrderId,
        Guid StoreOrderId,
        Guid StoreProductItemOrderId,
        UpdateOrderItemsRequest OrderItems) : IRequest<bool>;
    public record UpdateOrderItemsRequest(int Quantity);
    public class UpdateOrderItemsHandler : IRequestHandler<UpdateOrderItemsCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOrderItemsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateOrderItemsCommand request, CancellationToken cancellationToken)
        {
            var order = _unitOfWork.OrderRepository.GetAllAsync(
                predicate: x => x.Id == request.OrderId,
                include: source => source
                    .Include(x => x.StoreOrders)
                    .ThenInclude(x => x.StoreProductItemsOrders)
            );
            if (order == null || !order.Result.Any())
            {
                throw new AppExceptions("Order not found");
            }
            var storeOrder = order.Result.FirstOrDefault()?.StoreOrders
                .FirstOrDefault(x => x.Id == request.StoreOrderId);
            if (storeOrder == null)
            {
                throw new AppExceptions("Store order not found");
            }
            var storeProductItemOrder = storeOrder.StoreProductItemsOrders
                .FirstOrDefault(x => x.Id == request.StoreProductItemOrderId);
            if (storeProductItemOrder == null)
            {
                throw new AppExceptions("Store product item order not found");
            }
            if (request.OrderItems.Quantity <= 0)
            {
                throw new AppExceptions("Quantity must be greater than zero");
            }
            storeProductItemOrder.Quantity = request.OrderItems.Quantity;
            _unitOfWork.StoreProductItemOrderRepository.Update(storeProductItemOrder);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}

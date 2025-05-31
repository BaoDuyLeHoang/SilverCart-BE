using MediatR;
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
        Guid OrderItemId,
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
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderId);
            if (order == null)
                throw new KeyNotFoundException($"Order with ID '{request.OrderId}' not found.");

            var orderItem = order.OrderItems.FirstOrDefault(x => x.Id == request.OrderItemId);
            if (orderItem == null)
                throw new KeyNotFoundException($"Order item with ID '{request.OrderItemId}' not found.");

            if (orderItem.Status != OrderItemStatusEnums.Pending)
                throw new InvalidOperationException($"Order item with ID '{request.OrderItemId}' is not in a state that can be updated.");

            orderItem.Quantity = request.OrderItems.Quantity;
            _unitOfWork.OrderItemRepository.Update(orderItem);
            //calculate order total
            order.TotalPrice = (double)order.OrderItems.Sum(x => x.Quantity * x.StoreProductItem.ProductItem.DiscountedPrice);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}

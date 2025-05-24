using SilverCart.Application.Features.Orders.Integration.Messages;

namespace SilverCart.Application.Features.Orders.Integration;

public interface IOrderMessageProducer
{
    Task PublishOrderCreatedAsync(OrderCreatedMessage message);
    Task PublishOrderItemsAsync(IEnumerable<OrderItemMessage> items);
    Task PublishOrderStatusChangedAsync(Guid orderId, string status);
}
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using SilverCart.Application.Features.Orders.Integration;
using SilverCart.Application.Features.Orders.Integration.Messages;

namespace SilverCart.Infrastructure.Integration.Kafka;

public class OrderMessageProducer : IOrderMessageProducer, IDisposable
{
    private readonly IProducer<string, string> _producer;
    private readonly string _ordersTopic;

    public OrderMessageProducer(IOptions<KafkaSettings> settings)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = settings.Value.BootstrapServers,
            SecurityProtocol = Enum.Parse<SecurityProtocol>(settings.Value.SecurityProtocol),
            SaslMechanism = Enum.Parse<SaslMechanism>(settings.Value.SaslMechanism),
            SaslUsername = settings.Value.SaslUsername,
            SaslPassword = settings.Value.SaslPassword,
            EnableIdempotence = true,
            MessageTimeoutMs = settings.Value.MessageTimeoutMs,
            Acks = Acks.All
        };

        _producer = new ProducerBuilder<string, string>(config).Build();
        _ordersTopic = settings.Value.OrdersTopic;
    }

    public async Task PublishOrderCreatedAsync(OrderCreatedMessage message)
    {
        var value = JsonSerializer.Serialize(message);
        await PublishMessageAsync(message.OrderId.ToString(), value, "order-created");
    }

    public async Task PublishOrderItemsAsync(IEnumerable<OrderItemMessage> items)
    {
        var value = JsonSerializer.Serialize(items);
        await PublishMessageAsync(Guid.NewGuid().ToString(), value, "order-items");
    }

    public async Task PublishOrderStatusChangedAsync(Guid orderId, string status)
    {
        var message = new { OrderId = orderId, Status = status, Timestamp = DateTime.UtcNow };
        var value = JsonSerializer.Serialize(message);
        await PublishMessageAsync(orderId.ToString(), value, "order-status");
    }

    private async Task PublishMessageAsync(string key, string value, string messageType)
    {
        try
        {
            var message = new Message<string, string>
            {
                Key = key,
                Value = value,
                Headers = new Headers { { "message-type", System.Text.Encoding.UTF8.GetBytes(messageType) } }
            };

            var deliveryResult = await _producer.ProduceAsync(_ordersTopic, message);

            if (deliveryResult.Status == PersistenceStatus.NotPersisted)
            {
                throw new Exception($"Message failed to persist to Kafka. Status: {deliveryResult.Status}");
            }
        }
        catch (ProduceException<string, string> ex)
        {
            throw new Exception($"Failed to publish message to Kafka. Error: {ex.Error.Reason}", ex);
        }
    }

    public void Dispose()
    {
        _producer?.Dispose();
    }
}
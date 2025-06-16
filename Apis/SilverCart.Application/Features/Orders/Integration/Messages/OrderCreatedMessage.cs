namespace SilverCart.Application.Features.Orders.Integration.Messages;

public record OrderCreatedMessage(
    Guid OrderId,
    string CustomerName,
    string CustomerEmail,
    decimal TotalAmount,
    DateTime CreatedAt
);

public record OrderItemMessage(
    Guid ItemId,
    string ProductName,
    int Quantity,
    decimal UnitPrice
);
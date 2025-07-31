using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.Create;

public sealed record CreateOrderCommand(
    List<CreateOrderItemCommand> OrderItems,
    CreateOrderInfoCommand OrderInfo,
    Guid? UserPromotionId = null,
    int Points = 0
) : IRequest<CreateOrderResponse>;

public record CreateOrderItemCommand(
    Guid ProductItemId,
    int Quantity,
    string? Notes = null
);

public record CreateOrderInfoCommand(
    PaymentMethodEnum PaymentMethod,
    string? Note = null
);

public record CreateOrderResponse(
    Guid Id,
    decimal TotalPrice,
    decimal FinalPrice,
    OrderStatusEnum OrderStatus,
    DateTime CreationDate,
    List<CreateOrderDetailResponse> OrderDetails
);

public record CreateOrderDetailResponse(
    Guid Id,
    Guid ProductItemId,
    string ProductName,
    string SKU,
    int Quantity,
    decimal Price
);
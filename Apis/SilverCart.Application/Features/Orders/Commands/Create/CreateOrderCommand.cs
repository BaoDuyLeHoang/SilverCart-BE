using MediatR;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.Create;
public sealed record CreateOrderCommand(List<CreateOrderItemCommand> OrderItems, Guid? UserPromotionId = null, string? Notes = null) : IRequest<CreateOrderResponse>;
public record CreateOrderItemCommand(Guid ProductItemId, int Quantity, string? Notes = null);
public record CreateOrderResponse(Guid Id, decimal TotalPrice, OrderStatusEnum OrderStatus, DateTime CreationDate, List<CreateOrderDetailResponse> OrderDetails);
public record CreateOrderDetailResponse(Guid Id, Guid ProductItemId, string ProductName, string VariantName, string SKU, int Quantity, decimal Price);
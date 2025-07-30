using SilverCart.Domain.Entities.Orders;

namespace SilverCart.Application.Services.System;

public interface IGhnOrderService
{
    Task UpdateOrderGhnInfo(string clientOrderCode, string ghnOrderCode, string status, decimal totalFee);
    Task UpdateOrderStatus(string orderCode, string status, string reason, string reasonCode);
    Task UpdateOrderWeight(string orderCode, int weight, int convertedWeight);
    Task UpdateOrderCod(string orderCode, decimal codAmount, DateTime? codTransferDate);
    Task UpdateOrderFee(string orderCode, decimal totalFee, GhnWebhookFee fee);
}
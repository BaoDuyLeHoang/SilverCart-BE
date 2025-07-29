using Microsoft.AspNetCore.Mvc;
using SilverCart.Domain.Entities.Orders;
using SilverCart.Application.Services.System;

namespace SilverCart.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GhnWebhookController : ControllerBase
{
    private readonly ILogger<GhnWebhookController> _logger;
    private readonly IGhnOrderService _orderService;

    public GhnWebhookController(
        ILogger<GhnWebhookController> logger,
        IGhnOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpPost("callback/order-status")]
    public async Task<ActionResult<bool>> HandleCallback([FromBody] GhnWebhookResponse webhook)
    {
        try
        {
            _logger.LogInformation("Received GHN webhook: {@Webhook}", webhook);

            // Xử lý các loại callback khác nhau
            switch (webhook.Type.ToLower())
            {
                case "create":
                    await HandleOrderCreated(webhook);
                    break;

                case "switch_status":
                    await HandleStatusChanged(webhook);
                    break;

                case "update_weight":
                    await HandleWeightUpdated(webhook);
                    break;

                case "update_cod":
                    await HandleCodUpdated(webhook);
                    break;

                case "update_fee":
                    await HandleFeeUpdated(webhook);
                    break;

                default:
                    _logger.LogWarning("Unknown webhook type: {Type}", webhook.Type);
                    break;
            }

            // GHN yêu cầu trả về status code 200
            return Ok(true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing GHN webhook");
            // Vẫn trả về 200 để GHN không gửi lại webhook
            return Ok(true);
        }
    }

    private async Task HandleOrderCreated(GhnWebhookResponse webhook)
    {
        await _orderService.UpdateOrderGhnInfo(
            webhook.ClientOrderCode,
            webhook.OrderCode,
            webhook.Status,
            webhook.TotalFee);
    }

    private async Task HandleStatusChanged(GhnWebhookResponse webhook)
    {
        // Cập nhật trạng thái đơn hàng
        await _orderService.UpdateOrderStatus(
            webhook.OrderCode,
            webhook.Status,
            webhook.Reason,
            webhook.ReasonCode);
    }

    private async Task HandleWeightUpdated(GhnWebhookResponse webhook)
    {
        await _orderService.UpdateOrderWeight(
            webhook.OrderCode,
            webhook.Weight,
            webhook.ConvertedWeight);
    }

    private async Task HandleCodUpdated(GhnWebhookResponse webhook)
    {
        await _orderService.UpdateOrderCod(
            webhook.OrderCode,
            webhook.CodAmount,
            webhook.CodTransferDate);
    }

    private async Task HandleFeeUpdated(GhnWebhookResponse webhook)
    {
        await _orderService.UpdateOrderFee(
            webhook.OrderCode,
            webhook.TotalFee,
            webhook.Fee);
    }
}
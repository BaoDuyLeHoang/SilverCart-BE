using System.Text.Json.Serialization;

namespace SilverCart.Domain.Entities.Orders;

public class GhnWebhookResponse
{
    public decimal CodAmount { get; set; }

    public DateTime? CodTransferDate { get; set; }

    public string ClientOrderCode { get; set; } = string.Empty;

    public int ConvertedWeight { get; set; }

    public string Description { get; set; } = string.Empty;

    public GhnWebhookFee Fee { get; set; } = new();

    public int Height { get; set; }

    public bool IsPartialReturn { get; set; }

    public int Length { get; set; }

    public string OrderCode { get; set; } = string.Empty;

    public string PartialReturnCode { get; set; } = string.Empty;

    public int PaymentType { get; set; }

    public string Reason { get; set; } = string.Empty;

    public string ReasonCode { get; set; } = string.Empty;

    public int ShopId { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime Time { get; set; }

    public decimal TotalFee { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Warehouse { get; set; } = string.Empty;

    public int Weight { get; set; }

    public int Width { get; set; }
}

public class GhnWebhookFee
{
    public decimal CodFailedFee { get; set; }

    public decimal CodFee { get; set; }

    public decimal Coupon { get; set; }

    public decimal DeliverRemoteAreasFee { get; set; }

    public decimal DocumentReturn { get; set; }

    public decimal DoubleCheck { get; set; }

    public decimal Insurance { get; set; }

    public decimal MainService { get; set; }

    public decimal PickRemoteAreasFee { get; set; }

    public decimal R2S { get; set; }

    public decimal Return { get; set; }

    public decimal StationDo { get; set; }

    public decimal StationPu { get; set; }

    public decimal Total { get; set; }
}
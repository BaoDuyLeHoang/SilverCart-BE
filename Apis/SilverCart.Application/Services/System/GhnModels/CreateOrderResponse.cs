namespace SilverCart.Application.Services.System;

public class CreateOrderResponse
{
    public string OrderCode { get; set; } = string.Empty;
    public string SortCode { get; set; } = string.Empty;
    public string TransType { get; set; } = string.Empty;
    public string WardEncode { get; set; } = string.Empty;
    public string DistrictEncode { get; set; } = string.Empty;
    public OrderFee Fee { get; set; } = new();
    public string TotalFee { get; set; } = string.Empty;
    public DateTime ExpectedDeliveryTime { get; set; }
}

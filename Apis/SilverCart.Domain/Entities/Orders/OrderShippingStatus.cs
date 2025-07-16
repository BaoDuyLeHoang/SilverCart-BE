using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class OrderShippingStatus
{
    public Guid Id { get; set; }
    public ShippingStatusEnum? Status { get; set; }
    public string? TrackingCode { get; set; }
    public string? TrackingUrl { get; set; }
    public string? TrackingMessage { get; set; }
    public string? ShipSource { get; set; }
    public DateTime? TrackingTime { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Orders;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class Order : BaseEntity
{
    public decimal TotalPrice { get; set; }
    public decimal FinalPrice { get; set; }
    public string? OrderNote { get; set; }
    public string Address { get; set; } = string.Empty;
    public int EarnedPoints { get; set; }
    public int UsedPoints { get; set; }
    public OrderStatusEnum OrderStatus { get; set; }
    public string? OrderGhnCode { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public DateTime? CancelledAt { get; set; }

    // Owned by Order
    public OrderPaymentStatus PaymentStatus { get; set; } = null!;
    public OrderShippingStatus ShippingStatus { get; set; } = null!;
    // Navigation properties
    public Guid? GuardianId { get; set; }
    public virtual GuardianUser? Guardian { get; set; }
    public Guid? CustomerUserId { get; set; }
    public CustomerUser? CustomerUser { get; set; }
    public Guid? UserPromotionId { get; set; }
    public virtual UserPromotion? UserPromotion { get; set; }
    public Guid? DependentUserID { get; set; }
    public DependentUser? DependentUser { get; set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}

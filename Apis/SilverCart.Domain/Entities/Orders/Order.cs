using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Orders;
using SilverCart.Domain.Entities.Promotions;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class Order : BaseEntity
{
    public decimal TotalPrice { get; set; }
    public decimal FinalPrice { get; set; }
    public string? OrderNote { get; set; }
    public string OrderCode { get; set; } = string.Empty;
    public string FromAddress { get; set; } = string.Empty;
    public string ToAddress { get; set; } = string.Empty;
    public OrderStatusEnum OrderStatus { get; set; }
    public int EarnedPoints { get; set; }
    public int UsedPoints { get; set; }
    public DateTime? ConfirmedAt { get; set; }// confirmed by Guardian 
    public DateTime? CancelledAt { get; set; }// cancelled by any user

    // Owned by Order
    public OrderPaymentStatus PaymentStatus { get; set; } = null!;
    public OrderShippingStatus ShippingStatus { get; set; } = null!;
    // Navigation properties
    public Guid? OrderedUserId { get; set; }
    public BaseUser? OrderedUser { get; set; }
    public Guid? ConfirmUserId { get; set; }
    public GuardianUser? ConfirmUser { get; set; }
    public Guid? RecieveUserId { get; set; }
    public CustomerUser? RecieveUser { get; set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    // Notmapped properties
    [NotMapped]
    public bool? IsConfirmed => ConfirmedAt.HasValue;
    [NotMapped]
    public bool? IsCancelled => CancelledAt.HasValue;


}

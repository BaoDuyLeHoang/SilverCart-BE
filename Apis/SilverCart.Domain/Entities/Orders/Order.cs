using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Orders;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class Order : BaseEntity
{
    public RankEnum UserRank { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatusEnums OrderStatus { get; set; } = OrderStatusEnums.Pending;
    public Guid? DependentUserID { get; set; }
    public DependentUser? DependentUser { get; set; }
    public Guid? GuardianId { get; set; }
    public GuardianUser? Guardian { get; set; }
    public string OrderGhnCode { get; set; } = string.Empty;
    public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    public Guid? UserPromotionId { get; set; }
    public Guid? CustomerUserId { get; set; }
    public CustomerUser? CustomerUser { get; set; }
    public virtual UserPromotion? UserPromotion { get; set; }
}
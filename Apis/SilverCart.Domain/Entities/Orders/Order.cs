using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class Order : BaseEntity
{
    public RankEnum UserRank { get; set; }
    public double TotalPrice { get; set; }
    public OrderStatusEnums OrderStatus { get; set; } = OrderStatusEnums.Pending; //Default
    public Guid CustomerId { get; set; }
    public virtual CustomerUser Customer { get; set; } = null!;
    // Navigation properties
    public ICollection<StoreOrder> StoreOrders { get; set; } = new List<StoreOrder>();

    public Guid? UserPromotionId { get; set; }
    public virtual UserPromotion? UserPromotion { get; set; }
    // public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
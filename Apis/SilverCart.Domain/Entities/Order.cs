using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class Order : BaseEntity
{
    public RankEnum UserRank { get; set; }
    public double TotalPrice { get; set; }
    public OrderStatusEnums OrderStatus { get; set; } = OrderStatusEnums.Pending; //Default
    public DateTime? DeadlineDate { get; set; } //Thời gian giao hàng dự kiến
    public DateTime? EstimatedArrivedDate { get; set; } //Dự kiến thời gian giao hàng
    public DateTime? ArrivedDate { get; set; } //Sau khi tới thì ghi nhận thời gian nhận hàng
    public Guid CustomerId { get; set; }
    public virtual CustomerUser Customer { get; set; } = null!;
    // Navigation properties
    public Guid? UserPromotionId { get; set; }
    public virtual UserPromotion? UserPromotion { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
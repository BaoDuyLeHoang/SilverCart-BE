using Domain.Enums;

namespace Domain.Entities;

public class Order : BaseFullEntity
{
    public string Address { get; set; }
    public RankEnum UserRank { get; set; }
    public double TotalPrice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime DeadlineDate { get; set; }
    public DateTime EstimatedArrivedDate { get; set; }
    public DateTime ArrivedDate { get; set; }

    // Navigation properties
    public int? UserPromotionId { get; set; }
    public virtual UserPromotion? UserPromotion { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
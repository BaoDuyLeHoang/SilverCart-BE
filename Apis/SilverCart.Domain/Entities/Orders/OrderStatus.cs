using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class OrderStatus : BaseEntity
{
    public OrderStatusEnum Status { get; set; }
    public string Description { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
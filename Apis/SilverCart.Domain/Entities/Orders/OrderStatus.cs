namespace SilverCart.Domain.Entities;

public class OrderStatus : BaseEntity
{
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
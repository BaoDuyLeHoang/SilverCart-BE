namespace Domain.Entities;

public class OrderStatus : BaseFullEntity
{
    public string Status { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Navigation property
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
namespace Domain.Entities;

public class OrderItem : BaseFullEntity
{
    public double Price { get; set; }

    public int Quantity { get; set; }

    // Navigation properties
    public Guid ProductItemId { get; set; }
    public virtual ProductItem ProductItem { get; set; } = null!;
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
}
namespace Domain.Entities;

public class OrderItem
{
    public double Price { get; set; }

    public int Quantity { get; set; }

    // Navigation properties
    public int ProductItemId { get; set; }
    public virtual ProductItem ProductItem { get; set; } = null!;
    public int OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
}
namespace Domain.Entities;

public class CartItem : BaseFullEntity
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public decimal TotalPrice { get; set; }

    public bool IsSelected { get; set; } = true;

    // Navigation properties
    public int CartId { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
    public int ProductItemId { get; set; }
    public virtual ProductItem ProductItem { get; set; } = null!;
    public int StoreId { get; set; }
    public virtual Store Store { get; set; } = null!;
}
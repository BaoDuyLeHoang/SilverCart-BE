namespace Domain.Entities;

public class StockHistory : BaseFullEntity
{
    public int Quantity { get; set; }
    
    // Navigation properties
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}
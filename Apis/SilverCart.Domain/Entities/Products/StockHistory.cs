namespace SilverCart.Domain.Entities;

public class StockHistory : BaseEntity
{
    public Guid StoreProductItemId { get; set; }
    public StoreProductItem StoreProductItem { get; set; } = default!;
    public DateTime Date { get; set; }
    public int QuantityChange { get; set; }
    public int StockAfterChange { get; set; }
    public string? Reason { get; set; }
}
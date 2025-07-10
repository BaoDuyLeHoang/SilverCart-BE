namespace SilverCart.Domain.Entities;

public class ProductItem : BaseEntity
{
    public string SKU { get; set; } = string.Empty;
    public decimal OriginalPrice { get; set; }
    public decimal DiscountedPrice { get; set; }
    public int Weight { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Stock { get; set; } = 0;
    public bool IsActive { get; set; } = true;

    // Foreign keys
    public Guid VariantId { get; set; }
    public virtual ProductVariant Variant { get; set; } = null!;

    public Guid StoreId { get; set; }
    public virtual Store Store { get; set; } = null!;

    // Navigation properties
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public virtual ICollection<StockHistory> StockHistories { get; set; } = new List<StockHistory>();
}
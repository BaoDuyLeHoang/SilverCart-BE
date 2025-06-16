namespace SilverCart.Domain.Entities;

public class ProductItem : BaseEntity
{
    public string SKU { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountedPrice { get; set; }
    public int Weight { get; set; }
    // Navigation to related items (if needed)
    public Guid VariantId { get; set; }
    public ProductVariant Variant { get; set; }
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public virtual ICollection<StoreProductItem> StoreProductItems { get; set; } = new List<StoreProductItem>();
    // public virtual ICollection<ProductVariantItem> ProductVariantItems { get; set; } = new List<ProductVariantItem>();
}
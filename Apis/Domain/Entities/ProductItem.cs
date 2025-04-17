namespace Domain.Entities;

public class ProductItem:BaseFullEntity
{
    public string SKU { get; set; }
    public int Stock { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal DiscountedPrice { get; set; }
    
    // Navigation to related items (if needed)
    public Guid VariantId { get; set; }
    public ProductVariant Variant { get; set; }
    
    public Guid ProductImageId { get; set; }
    public ProductImage ProductImage { get; set; }
}
namespace SilverCart.Domain.Entities;

public class ProductVariant : BaseEntity
{
    public required string VariantName { get; set; }
    public decimal Price { get; set; }

    // Foreign key to Product
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    // Navigation to related items (if needed)
    public ICollection<ProductItem>? Items { get; set; }
}
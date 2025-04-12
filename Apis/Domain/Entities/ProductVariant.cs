namespace Domain.Entities;

public class ProductVariant : BaseFullEntity
{
    public string VariantName { get; set; }

    // Foreign key to Product
    public Guid ProductId { get; set; }
    public Product Product { get; set; }

    // Navigation to related items (if needed)
    public ICollection<ProductItem> Items { get; set; }
}
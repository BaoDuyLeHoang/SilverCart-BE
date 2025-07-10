namespace SilverCart.Domain.Entities;

public class ProductVariant : BaseEntity
{
    public required string VariantName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; } = 0;
    public bool IsActive { get; set; } = true;

    // Foreign key to Product
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    // Navigation to related items
    public virtual ICollection<ProductItem> Items { get; set; } = new List<ProductItem>();
}
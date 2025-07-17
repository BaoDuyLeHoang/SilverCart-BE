using SilverCart.Domain.Entities.Products;

namespace SilverCart.Domain.Entities;

public class ProductVariant : BaseEntity
{
    public required string VariantName { get; set; }
    public bool IsActive { get; set; } = true;
    // Foreign key to Product
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    // Navigation to related items
    public virtual ICollection<ProductItem> ProductItems { get; set; } = [];
}
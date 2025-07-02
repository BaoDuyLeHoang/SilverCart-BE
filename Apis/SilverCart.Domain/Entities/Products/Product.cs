using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? VideoPath { get; set; }
    public ProductTypeEnum ProductType { get; set; }
    // Navigation properties
    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    public virtual ICollection<ProductVariant>? Variants { get; set; }
    public virtual ICollection<ProductPromotion>? ProductPromotions { get; set; }
}
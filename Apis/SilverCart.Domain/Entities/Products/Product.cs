using SilverCart.Domain.Entities.Categories;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities.Products;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? VideoPath { get; set; }
    public ProductTypeEnum ProductType { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid StoreId { get; set; }
    public virtual Store Store { get; set; } = null!;
    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    public virtual ICollection<ProductPromotion> ProductPromotions { get; set; } = new List<ProductPromotion>();
    public virtual ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
}
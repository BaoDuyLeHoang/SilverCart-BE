using Domain.Enums;

namespace Domain.Entities;

public class Product : BaseFullEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string VideoPath { get; set; }
    public ProductTypeEnum ProductType { get; set; }


    // Navigation properties
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<ProductVariant> Variants { get; set; }
    public virtual ICollection<ProductImage> Images { get; set; }
    public virtual ICollection<ProductPromotion> ProductPromotions { get; set; }
}
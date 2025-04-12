namespace Domain.Entities;

public class Product:BaseFullEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string VideoPath { get; set; }
    public ProductTypeEnum ProductType { get; set; }

    

    // Navigation properties
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<ProductVariant> Variants { get; set; }
    public virtual ICollection<ProductImage> Images { get; set; }
    public virtual ICollection<ProductPromotion> Promotions { get; set; }

    public enum ProductTypeEnum
    {
        Physical,
        Digital,
        Consumable,
        Service,
    }
}
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class Promotion : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Discount { get; set; }
    public PromotionDiscountTypeEnum DiscountType { get; set; }

    public bool IsActive { get; set; }

    // Contitional Properties
    public int MinimumQuantity { get; set; }
    public int MaximumQuantity { get; set; }
    public decimal MinimumPrice { get; set; }
    public decimal MaximumPrice { get; set; }

    // Navigation properties
    public virtual ICollection<ProductPromotion> ProductPromotions { get; set; } = new List<ProductPromotion>();


}
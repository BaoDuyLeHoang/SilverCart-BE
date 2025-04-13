namespace Domain.Entities;

public class ProductPromotion : BaseFullEntity
{
    public int ProductId { get; set; }
    public int PromotionId { get; set; }

    public virtual Product Product { get; set; } = null!;
    public virtual Promotion Promotion { get; set; } = null!;
}
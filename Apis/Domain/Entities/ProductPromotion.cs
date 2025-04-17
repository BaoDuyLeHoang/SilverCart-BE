namespace Domain.Entities;

public class ProductPromotion : BaseFullEntity
{
    public Guid ProductId { get; set; }
    public Guid PromotionId { get; set; }

    public virtual Product Product { get; set; } = null!;
    public virtual Promotion Promotion { get; set; } = null!;
}
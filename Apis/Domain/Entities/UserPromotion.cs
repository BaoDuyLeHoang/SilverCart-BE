namespace Domain.Entities;

public class UserPromotion : BaseFullEntity
{
    // Navigation properties
    public int UserId { get; set; }
    public virtual CustomerUser User { get; set; } = null!;
    public int PromotionId { get; set; }
    public virtual Promotion Promotion { get; set; } = null!;
}
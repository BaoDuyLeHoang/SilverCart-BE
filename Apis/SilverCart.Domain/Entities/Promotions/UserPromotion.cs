using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities.Promotions;

public class UserPromotion : BaseEntity
{
    public bool IsUsed { get; set; }
    public DateTime? UsedAt { get; set; }
    public Guid UserId { get; set; }
    public virtual BaseUser User { get; set; } = null!;
    public Guid PromotionId { get; set; }
    public virtual Promotion Promotion { get; set; } = null!;
}
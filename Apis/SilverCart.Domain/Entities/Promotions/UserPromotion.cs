using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities;

public class UserPromotion : BaseEntity
{
    // Navigation properties
    public Guid UserId { get; set; }
    public virtual CustomerUser User { get; set; } = null!;
    public Guid PromotionId { get; set; }
    public virtual Promotion Promotion { get; set; } = null!;
}
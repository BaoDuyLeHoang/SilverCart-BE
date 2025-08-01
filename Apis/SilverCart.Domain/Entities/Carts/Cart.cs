using SilverCart.Domain.Entities.Stores;
using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities.Carts;

public class Cart : BaseEntity
{
    public Guid UserId { get; set; }
    public bool ConsultantRecommendation { get; set; } = false;

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public decimal TotalPrice { get; set; } = 0;

    public bool IsConsultantUserRecommend { get; set; } = false;

    // User relationships
    public Guid? CustomerUserId { get; set; }
    public virtual CustomerUser? CustomerUser { get; set; }

    public Guid? GuardianUserId { get; set; }
    public virtual GuardianUser? GuardianUser { get; set; }
}
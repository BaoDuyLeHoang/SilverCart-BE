using SilverCart.Domain.Entities.Stores;
using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities.Carts;

public class Cart : BaseEntity
{

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public decimal TotalPrice { get; set; } = 0;

    public bool IsConsultantUserRecommend { get; set; } = false;

    // User relationships
    public Guid? UserId { get; set; }
    public virtual BaseUser? User { get; set; }
    public Guid? ConsultantUserId { get; set; }
    public virtual ConsultantUser? Consultant { get; set; }
}
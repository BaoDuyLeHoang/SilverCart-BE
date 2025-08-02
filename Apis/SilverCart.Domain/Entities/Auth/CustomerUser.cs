using SilverCart.Domain.Entities.Carts;
using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Entities.Promotions;

namespace SilverCart.Domain.Entities.Auth;

public class CustomerUser : BaseUser
{
    public CustomerUser()
    {
        // Customer-specific initialization
    }

    // Customer-specific properties
    public Guid RankId { get; set; }
    public ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; } = new List<CustomerPaymentMethod>();

    // Customer-specific navigation properties (moved from BaseUser)
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public virtual ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();
    public virtual ICollection<UserPromotion> UserPromotions { get; set; } = new List<UserPromotion>();
    public virtual Wallet? Wallet { get; set; }
    public Guid? GuardianUserId { get; set; }
}
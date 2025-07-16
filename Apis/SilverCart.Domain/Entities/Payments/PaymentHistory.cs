using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities.Payments;

public class PaymentHistory : BaseEntity
{
    public decimal? Amount { get; set; }
    public int? Points { get; set; }
    public string Note { get; set; } = string.Empty;

    // Navigation properties
    public Guid CustomerUserId { get; set; }
    public CustomerUser CustomerUser { get; set; } = null!;

    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;
    public Guid? OrderId { get; set; }
    public Order? Order { get; set; }

    public Guid? PromotionId { get; set; }
    public Promotion? Promotion { get; set; }

    public Guid? WalletId { get; set; }
    public Wallet? Wallet { get; set; }
}

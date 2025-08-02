using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities.Payments;

public class PaymentHistory : BaseEntity
{
    public double Amount { get; set; }
    public double PreviousBalance { get; set; }
    public double NewBalance { get; set; }
    public double? Points { get; set; }
    public string Note { get; set; } = string.Empty;
    public PaymentStatusEnum? Status { get; set; } = PaymentStatusEnum.Pending;
    // Navigation properties
    public Guid? PaymentMethodId { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public Guid? PromotionId { get; set; }
    public Promotion? Promotion { get; set; }
    public Guid? WalletId { get; set; }
    public Wallet? Wallet { get; set; }
    public Guid? UserId { get; set; }
    public BaseUser? User { get; set; }
}

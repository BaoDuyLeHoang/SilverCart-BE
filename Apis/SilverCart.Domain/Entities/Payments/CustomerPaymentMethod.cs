
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Payments;

namespace SilverCart.Domain.Entities.Payments;

public class CustomerPaymentMethod : BaseEntity
{
    public bool IsDefault { get; set; }
    public string? CardLastFourDigits { get; set; }
    public string? CardType { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? CardholderName { get; set; }
    public string? BillingAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public Guid CustomerId { get; set; }
    public virtual DependentUser Customer { get; set; } = null!;
    public Guid PaymentMethodId { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
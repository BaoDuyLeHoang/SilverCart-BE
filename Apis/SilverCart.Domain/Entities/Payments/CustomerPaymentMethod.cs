
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Payments;

namespace SilverCart.Domain.Entities;

public class CustomerPaymentMethod : BaseEntity
{
    public bool IsDefault { get; set; }
    // Navigation properties
    public Guid CustomerId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public virtual CustomerUser Customer { get; set; } = null!;
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
    public virtual ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();
}
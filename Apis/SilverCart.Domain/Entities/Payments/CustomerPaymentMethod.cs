using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities;

public class CustomerPaymentMethod : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public bool IsDefault { get; set; }

    public virtual CustomerUser Customer { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; }
}
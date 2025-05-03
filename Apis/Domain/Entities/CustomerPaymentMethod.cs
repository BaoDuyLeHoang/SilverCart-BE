namespace Domain.Entities;

public class CustomerPaymentMethod : BaseFullEntity
{
    public Guid CustomerId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public bool IsDefault { get; set; }

    public virtual CustomerUser Customer { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; }
}
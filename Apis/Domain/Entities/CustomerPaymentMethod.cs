namespace Domain.Entities;

public class CustomerPaymentMethod : BaseEntity
{
    public string CustomerId { get; set; }
    public string PaymentMethodId { get; set; }
    public bool IsDefault { get; set; }

    public virtual CustomerUser Customer { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; }
}
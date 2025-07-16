namespace SilverCart.Domain.Entities.Payments;

public sealed class PaymentMethod : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string IconPath { get; set; } = null!;
    public bool IsActive { get; set; }
    public int Order { get; set; }

    // Navigation properties
    public ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; } = new List<CustomerPaymentMethod>();
    public ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();
}
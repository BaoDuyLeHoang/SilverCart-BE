using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities.Orders;

public class OrderPaymentStatus
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethodEnum PaymentMethod { get; set; }
    public PaymentStatusEnum PaymentStatus { get; set; }
    public Guid? PaidById { get; set; }
    public BaseUser? PaidUser { get; set; }

}

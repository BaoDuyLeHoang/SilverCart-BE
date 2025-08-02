using SilverCart.Domain.Entities.Payments;

namespace SilverCart.Domain.Entities.Auth;

public class Wallet : BaseEntity
{
    public int Balance { get; set; }
    public int Points { get; set; }
    public int TotalSpent { get; set; } = 0;
    public int TotalReceived { get; set; } = 0;
    public int TotalRefunded { get; set; } = 0;
    public Guid UserId { get; set; }
    public BaseUser User { get; set; } = null!;
    public ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();
}

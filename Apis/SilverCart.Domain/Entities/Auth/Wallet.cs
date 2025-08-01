using SilverCart.Domain.Entities.Payments;

namespace SilverCart.Domain.Entities.Auth;

public class Wallet : BaseEntity
{
    public int Balance { get; set; }
    public int Points { get; set; }
    public int TotalSpent { get; set; } = 0;
    public int TotalReceived { get; set; } = 0;
    public int TotalRefunded { get; set; } = 0;
    public Guid? GuardianUserId { get; set; }
    public GuardianUser? GuardianUser { get; set; }
    public Guid? UserId { get; set; }
    public CustomerUser? User { get; set; } = null!;
    public ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();
}

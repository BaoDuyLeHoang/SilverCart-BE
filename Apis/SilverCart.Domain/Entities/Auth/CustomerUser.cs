using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities.Auth;

public sealed class CustomerUser : BaseUser
{
    public CustomerUser()
    {
        Rank ??= new CustomerRank
        {
            Rank = RankEnum.Bronze
        };
    }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public Guid RankId { get; set; }
    public CustomerRank Rank { get; set; } = null!;
    public ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; } = new List<CustomerPaymentMethod>();
    public Wallet? Wallet { get; set; }
    public ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();
}

public class Wallet : BaseEntity
{
    public int Balance { get; set; }
    public int Points { get; set; }
    public int TotalSpent { get; set; } = 0;
    public int TotalReceived { get; set; } = 0;
    public int TotalRefunded { get; set; } = 0;
    public ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();
}

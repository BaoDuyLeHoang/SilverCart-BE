
using SilverCart.Domain.Entities.Carts;
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
    public List<Cart> Carts { get; set; } = new List<Cart>();
    public ICollection<CustomerPaymentMethod> CustomerPaymentMethods { get; set; } = new List<CustomerPaymentMethod>();
    public Wallet? Wallet { get; set; }
    public ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();
    public ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
}

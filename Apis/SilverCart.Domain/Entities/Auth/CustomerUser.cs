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
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public Guid RankId { get; set; }
    public CustomerRank Rank { get; set; } = null!;
}

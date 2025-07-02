using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class CustomerRank : BaseEntity
{
    public RankEnum Rank { get; set; }

    // Navigation property
    public Guid CustomerId { get; set; }
    public virtual CustomerUser Customer { get; set; } = null!;
}

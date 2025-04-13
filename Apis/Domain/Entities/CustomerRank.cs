using Domain.Enums;

namespace Domain.Entities;

public class CustomerRank : BaseFullEntity
{
    public RankEnum Rank { get; set; }

    // Navigation property
    public int CustomerId { get; set; }
    public virtual CustomerUser Customer { get; set; } = null!;
}

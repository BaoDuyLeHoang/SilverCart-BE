namespace Domain.Entities;

public class CustomerUser : BaseUser
{
    // Navigation Properties
    public Guid RankId { get; set; }
    public virtual CustomerRank Rank { get; set; } = null!;
}
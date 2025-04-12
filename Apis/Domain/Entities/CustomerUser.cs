namespace Domain.Entities;

public class CustomerUser : BaseUser
{
    // Navigation Properties
    public int RankId { get; set; }
    public virtual CustomerRank Rank { get; set; } = null!;
}
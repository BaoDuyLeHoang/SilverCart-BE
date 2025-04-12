namespace Domain.Entities;

public class CustomerRank : BaseFullEntity
{
    public RankEnum Rank { get; set; }

    // Navigation property
    public int CustomerId { get; set; }
    public virtual CustomerUser Customer { get; set; } = null!;

    public enum RankEnum
    {
        Bronze = 1,
        Silver = 2,
        Gold = 3,
        Platinum = 4,
        Diamond = 5
    }
}
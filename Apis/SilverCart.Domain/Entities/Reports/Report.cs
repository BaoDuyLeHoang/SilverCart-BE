namespace SilverCart.Domain.Entities;

public class Report : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    // Navigation property
}
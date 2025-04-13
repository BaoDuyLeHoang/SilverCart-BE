namespace Domain.Entities;

public class PaymentMethodHistory : BaseFullEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string IconPath { get; set; } = null!; // 50x50

    public bool IsActive { get; set; }

    // public int Order { get; set; }
    public string? AdditionalInfo { get; set; }

    // Navigation properties
    public CustomerUser CreatedBy { get; set; } = null!;
    public int PaymentMethodId { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
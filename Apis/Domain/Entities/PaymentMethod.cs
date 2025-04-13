namespace Domain.Entities;

public class PaymentMethod : BaseFullEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string IconPath { get; set; } = null!;
    public bool IsActive { get; set; }
    public int Order { get; set; }
    public string? AdditionalInfo { get; set; }

    // Navigation properties
    public virtual AdministratorUser CreatedBy { get; set; } = null!;
    public virtual ICollection<PaymentMethodHistory> PaymentMethodHistories { get; set; } = new List<PaymentMethodHistory>();
}
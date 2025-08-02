
using SilverCart.Domain.Entities.Carts;
using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities.Auth;

public sealed class DependentUser : CustomerUser
{
    public DependentUser()
    {
        // Dependent-specific initialization
    }

    // Guardian relationship (for dependent users)
    public Guid? GuardianId { get; set; }
    public GuardianUser? Guardian { get; set; }
    public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

    // Additional fields for dependent user functionality
    public DateTime? DateOfBirth { get; set; }
    public string? Relationship { get; set; }
    public string? MedicalNotes { get; set; }
    public decimal? MonthlySpendingLimit { get; set; }
    public Guid? AddressId { get; set; }

    // Helper properties
    public bool IsDependent => GuardianId.HasValue;
    public bool IsIndependent => !GuardianId.HasValue;
}

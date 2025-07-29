using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities;

public class CustomerAddress : BaseEntity
{
    // Navigation properties
    public Guid CustomerId { get; set; }
    public CustomerUser Customer { get; set; } = null!;
    public Guid AddressId { get; set; }
    public SavedAddress SavedAddress { get; set; } = null!;
}
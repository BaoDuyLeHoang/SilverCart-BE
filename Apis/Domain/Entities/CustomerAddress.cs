namespace Domain.Entities;

public class CustomerAddress : BaseFullEntity
{
    // Navigation properties
    public Guid CustomerId { get; set; }
    public CustomerUser Customer { get; set; } = null!;
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;
}
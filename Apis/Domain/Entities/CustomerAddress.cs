namespace Domain.Entities;

public class CustomerAddress : BaseFullEntity
{
    // Navigation properties
    public int CustomerId { get; set; }
    public CustomerUser Customer { get; set; } = null!;
    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;
}
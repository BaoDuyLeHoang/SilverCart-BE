using Domain.Common.Interfaces;

namespace Domain.Entities;

public class Address: BaseFullEntity,IUserTracking
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid? ModificationById { get; set; }
    public Guid? DeleteById { get; set; }
    
    // Navigation properties
}
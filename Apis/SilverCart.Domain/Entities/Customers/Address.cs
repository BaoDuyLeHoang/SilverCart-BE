using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities;

/// <summary>
/// <see cref="AddressConfiguration.cs"/>
/// </summary>
public class Address : BaseEntity
{
    public required string StreetAddress { get; set; }
    public string WardCode { get; set; }
    public int DistrictId { get; set; }
    public string ToDistrictName { get; set; }
    public string ToProvinceName { get; set; }
    public Guid? CustomerId { get; set; }
    public virtual CustomerUser? Customer { get; set; }
    public string FullAddress => $"{StreetAddress}, {WardCode}, {DistrictId}, {ToDistrictName}, {ToProvinceName}";
}
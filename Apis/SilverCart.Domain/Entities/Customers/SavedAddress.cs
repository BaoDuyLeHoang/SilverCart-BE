using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities;

/// <summary>
/// Saved Address only use to save User address in database.
/// Because we have GhnService to get Province, District, Ward information.
/// <see cref="AddressConfiguration.cs"/>
/// </summary>
public class SavedAddress : BaseEntity
{
    public required string StreetAddress { get; set; } // 123 Lê quí đôn 
    public int DistrictId { get; set; }
    public string DistrictName { get; set; } // Quận 1
    public int ProvinceId { get; set; }
    public string ProvinceName { get; set; } // Thành phố Hồ Chí Minh
    public string WardCode { get; set; } // "123456"
    public string WardName { get; set; } // Phường 1
    public string FullAddress => $"{StreetAddress}, {WardName}, {DistrictName}, {ProvinceName}";
    
  
}
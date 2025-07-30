namespace SilverCart.Application.Services.System;

public class CalculateShippingFeeRequest
{
    // Service type (2: Light goods, 5: Heavy goods)
    // if Length,Width,Height > 200cm or Weight > 50000g then ServiceTypeId = 5
    public int ServiceTypeId => Length > 200 || Width > 200 || Height > 200 || Weight > 50000 ? 5 : 2;

    // Required fields
    public required string ToWardCode { get; set; }
    public required int ToDistrictId { get; set; }

    public required int Weight { get; set; } // max 50.000 gram

    // Optional sender info (if not provided, will use shop info)
    public string? FromWardCode { get; set; }
    public int? FromDistrictId { get; set; }

    public int? Length { get; set; } // max 200 cm

    public int? Width { get; set; } // max 200 cm

    public int? Height { get; set; } // max 200 cm

    // Optional values
    public int? InsuranceValue { get; set; } // Maximum: 5,000,000 VND
    public string? Coupon { get; set; }
    public int? CodFailedAmount { get; set; }
    public int? CodValue { get; set; } // Maximum: 10,000,000 VND

    // Required for heavy goods (service_type_id = 5)
    public List<ShippingFeeItem>? Items { get; set; }
}

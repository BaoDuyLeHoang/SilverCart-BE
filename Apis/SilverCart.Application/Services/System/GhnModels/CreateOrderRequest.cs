using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Orders;
using SilverCart.Domain.Entities.Stores;
using SilverCart.Domain.Enums;

namespace SilverCart.Application.Services.System;

public class GhnCreateOrderRequest
{
    public GhnCreateOrderRequest() { }
    // Required fields Address 1
    public required string ToName { get; set; }
    public required string ToPhone { get; set; }
    public required string ToAddress { get; set; }
    public required string ToWardName { get; set; }
    public required string ToDistrictName { get; set; }
    public required string ToProvinceName { get; set; }
    public int ServiceTypeId => Weight > 50000 || Length > 200 || Width > 200 || Height > 200 ? 5 : 2; // 2: Hàng nhẹ, 5: Hàng nặng
    public required PaymentMethodEnum PaymentTypeId { get; set; } // 1: Người gửi trả tiền, 2: Người nhận trả tiền
    public required GhnRequireNoteEnum RequiredNote { get; set; } // CHOTHUHANG, CHOXEMHANGKHONGTHU, KHONGCHOXEMHANG

    // Address 2 
    public string? FromName { get; set; }
    public string? FromPhone { get; set; }
    public string? FromAddress { get; set; }
    public string? FromWardName { get; set; }
    public string? FromDistrictName { get; set; }
    public string? FromProvinceName { get; set; }

    // Return info
    public string? ReturnPhone { get; set; }
    public string? ReturnAddress { get; set; }
    public int? ReturnDistrictId { get; set; }
    public string? ReturnWardCode { get; set; }

    // Order details
    public string? ClientOrderCode { get; set; }
    public int? CodAmount { get; set; } // Số tiền cần thu hộ
    public string? Content { get; set; } // Nội dung hàng hóa

    public int? Length { get; set; } // max 200
    public int? Width { get; set; } // max 200
    public int? Height { get; set; } // max 200
    public int? Weight { get; set; } // max 50000

    public int? CodFailedAmount { get; set; } = 0;  // Số tiền cần thu hộ khi giao hàng thất bại
    public int? PickStationId { get; set; } // ID của trạm giao hàng
    public int? DeliverStationId { get; set; } // ID của trạm nhận hàng
    public int? InsuranceValue { get; set; } // Giá trị bảo hiểm
    public string? Note { get; set; } // Ghi chú
    public string? Coupon { get; set; } // Mã giảm giá
    public long? PickupTime { get; set; } // Thời gian giao hàng
    public int[]? PickShift { get; set; } // Ca giao hàng

    // Items (required for heavy goods service_type_id = 5)
    public List<GhnOrderItem>? Items { get; set; }

    public static GhnCreateOrderRequest ToCreateGHNOrder(BaseUser? user, List<OrderDetails> orderDetails, Store store
    , StoreAddress fromAddress, SavedAddress toSavedAddress, int weight, int length, int width, int height
    , PaymentMethodEnum paymentTypeId, string note)
    {
        return new GhnCreateOrderRequest
        {
            ToName = user.FullName,
            ToPhone = user.PhoneNumber,
            FromName = store.Name,
            FromPhone = store.Phone,
            FromAddress = fromAddress.StreetAddress,
            FromWardName = fromAddress.WardName,
            FromDistrictName = fromAddress.DistrictName,
            FromProvinceName = fromAddress.ProvinceName,
            ToAddress = toSavedAddress.StreetAddress,
            ToWardName = toSavedAddress.WardName,
            ToDistrictName = toSavedAddress.DistrictName,
            ToProvinceName = toSavedAddress.ProvinceName,
            PaymentTypeId = paymentTypeId,
            RequiredNote = GhnRequireNoteEnum.CHOTHUHANG,
            Weight = weight,
            Length = length,
            Width = width,
            Height = height,
            Note = note,
            Items = orderDetails.Select(od => new GhnOrderItem
            {
                Name = od.ProductItem.Variant.Product.Name,
                Quantity = od.Quantity,
                Price = od.Price
            }).ToList()
        };
    }
}

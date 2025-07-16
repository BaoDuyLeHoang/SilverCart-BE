namespace SilverCart.Domain.Enums;

public enum ShippingStatusEnum
{
    All = -1,
    Pending = 0,
    Shipping = 1,
    Delivered = 2,
    Completed = 3, // đã giao hàng
    Cancelled = 4, // đã hủy
    Refunded = 5, // đã hoàn
    Returned = 6 // đã trả
}
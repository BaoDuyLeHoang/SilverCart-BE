using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class OrderItem : BaseEntity
{
    public double Price { get; set; }
    public int Quantity { get; set; }
    public OrderItemStatusEnums Status { get; set; } = OrderItemStatusEnums.Pending;
    // Navigation properties
    public Guid StoreProductItemId { get; set; }
    public virtual StoreProductItem StoreProductItem { get; set; } = null!;
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;
}
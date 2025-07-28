using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities.Orders
{
    public class OrderDetails : BaseEntity
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        public Guid ProductItemId { get; set; }
        public virtual ProductItem ProductItem { get; set; } = null!;
        public OrderItemStatusEnums OrderItemStatus { get; set; } = OrderItemStatusEnums.Pending;
        // Shipping Required data
        public required int Weight { get; set; }
        public required int Length { get; set; }
        public required int Width { get; set; }
        public required int Height { get; set; }
        // Product Required data
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
        // Additional info for tracking
        public string? Notes { get; set; }
    }
}

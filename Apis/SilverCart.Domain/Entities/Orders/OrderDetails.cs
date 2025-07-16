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
        public int Weight { get; set; } = 0;
        public int Length { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        // Product Required data
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        // Additional info for tracking
        public string? Notes { get; set; }
    }
}

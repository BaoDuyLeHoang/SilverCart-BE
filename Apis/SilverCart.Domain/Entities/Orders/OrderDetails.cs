using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities.Orders
{
    public class OrderDetails : BaseEntity, IAuditableEntity
    {
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        public Guid ProductItemId { get; set; }
        public virtual ProductItem ProductItem { get; set; } = null!;
        public OrderItemStatusEnums OrderItemStatus { get; set; } = OrderItemStatusEnums.Pending;
        public int Weight { get; set; } = 0;
        public int Length { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        // Additional info for tracking
        public string? Notes { get; set; }
    }
}

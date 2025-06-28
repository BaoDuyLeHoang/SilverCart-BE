using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities
{
    public class StoreProductItemsOrder : BaseEntity
    {
        public Guid StoreProductItemId { get; set; }
        public StoreProductItem StoreProductItem { get; set; } = null!;
        public Guid StoreOrderId { get; set; }
        public StoreOrder StoreOrder { get; set; } = null!;
        public StoreProductItemsOrderStatus Status { get; set; } = StoreProductItemsOrderStatus.Pending;
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
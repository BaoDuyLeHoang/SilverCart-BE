using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities
{
    public class StoreOrder : BaseEntity
    {
        public double TotalPrice { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
        public StoreOrderStatus Status { get; set; } = StoreOrderStatus.Pending;
        public StoreOrderShippingGhnStatusEnum ShippingStatus { get; set; }
        public ICollection<StoreProductItemsOrder> StoreProductItemsOrders { get; set; } = new List<StoreProductItemsOrder>();
    }
}
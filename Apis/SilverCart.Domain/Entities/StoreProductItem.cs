using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities
{
    public class StoreProductItem : BaseEntity
    {
        public Guid? StoreId { get; set; }
        public Store Store { get; set; } = null!;
        public Guid ProductItemId { get; set; }
        public ProductItem ProductItem { get; set; } = null!;
        public int Stock { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<StockHistory> StockHistories { get; set; } = new List<StockHistory>();
    }
}

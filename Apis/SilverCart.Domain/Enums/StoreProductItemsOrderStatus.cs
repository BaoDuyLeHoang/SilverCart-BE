using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Enums
{
    public enum StoreProductItemsOrderStatus
    {
        Pending = 0,
        ConfirmedByGuardian = 1,
        Processing = 2,
        Shipping = 3,
        Completed = 4,
        Cancelled = 5,
        Refunded = 6,
        Failed = 7
    }
}

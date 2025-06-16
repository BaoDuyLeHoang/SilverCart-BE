using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Enums;

public enum OrderStatusEnums
{
    All = -1,
    Pending = 0,
    GuardianConfirmed = 1,
    StoreConfirmed = 2,
    Processing = 3,
    Shipping = 4,
    Completed = 5,
    Cancelled = 6,
    Mixed = 7
}

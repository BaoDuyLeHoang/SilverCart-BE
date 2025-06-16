using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Enums;
public enum OrderItemStatusEnums
{
    All = -1, //For filter
    Pending = 0,
    ConfirmedByGuardian = 1,
    ConfirmedByStore = 2,
    Preparing = 3,
    ReadyToShip = 4,
    Shipping = 5,
    Delivered = 6,
    Cancelled = 7,
    Returned = 8
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities
{
    public class StoreAddress : BaseEntity
    {
        public required string StreetAddress { get; set; }
        public string WardCode { get; set; }
        public int DistrictId { get; set; }
        public string FromDistrictName { get; set; }
        public string FromProvinceName { get; set; }
    }
}

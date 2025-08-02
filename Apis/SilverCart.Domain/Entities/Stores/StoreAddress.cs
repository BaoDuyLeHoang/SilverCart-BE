using System.ComponentModel.DataAnnotations.Schema;

namespace SilverCart.Domain.Entities.Stores
{
    public class StoreAddress : BaseEntity
    {
        public required string StreetAddress { get; set; } // 123 Lê quí đôn 
        public int DistrictId { get; set; }
        public string DistrictName { get; set; } // Quận 1
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; } // Thành phố Hồ Chí Minh
        public string WardCode { get; set; } // 123456
        public string WardName { get; set; } // Phường 1
        public Guid StoreId { get; set; }
        public virtual Store Store { get; set; } = null!;
        public string FullAddress => $"{StreetAddress}, {WardName}, {DistrictName}, {ProvinceName}";
    }
}

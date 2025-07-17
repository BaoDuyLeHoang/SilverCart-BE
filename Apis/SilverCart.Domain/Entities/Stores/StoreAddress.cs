using System.ComponentModel.DataAnnotations.Schema;

namespace SilverCart.Domain.Entities.Stores
{
    public class StoreAddress : BaseEntity
    {
        public string Address { get; set; } = string.Empty;
        public string WardCode { get; set; } = string.Empty;
        public int DistrictId { get; set; }
        public string WardName { get; set; } = string.Empty;
        public string DistrictName { get; set; } = string.Empty;
        public string ProvinceName { get; set; } = string.Empty;
        [NotMapped]
        public string FullAddress => $"{Address}, {WardName}, {DistrictName}, {ProvinceName}";
    }
}

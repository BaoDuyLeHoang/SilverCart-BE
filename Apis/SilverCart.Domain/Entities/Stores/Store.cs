namespace SilverCart.Domain.Entities.Stores;

public class Store : BaseEntity
{
    public required string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? AvatarPath { get; set; }
    public string? AdditionalInfo { get; set; }
    //For GHN
    public int? GhnShopId { get; set; }
    public bool IsGhnSynced { get; set; } = false;
    public string? Phone { get; set; }
    // Navigation properties
    public Guid StoreAddressId { get; set; }
    public StoreAddress StoreAddress { get; set; } = null!;
    public virtual ICollection<StoreUser> StoreUsers { get; set; } = [];
    public virtual ICollection<Product> Products { get; set; } = [];
}
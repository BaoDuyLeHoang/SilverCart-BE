namespace SilverCart.Domain.Entities;

public class Store : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Infomation { get; set; }
    public string AvatarPath { get; set; }
    public string? AdditionalInfo { get; set; }
    //For GHN

    public int? GhnShopId { get; set; }
    public bool IsGhnSynced { get; set; } = false;

    public bool IsBanned { get; set; }
    public bool IsActive { get; set; }
    public int IsVerified { get; set; }
    public Guid StoreAddressId { get; set; }
    public virtual StoreAddress StoreAddress { get; set; } = null!;
    // Navigation properties
    public virtual ICollection<StoreUser> StoreUsers { get; set; } = new List<StoreUser>(); //Employees
    public virtual ICollection<StoreProductItem> StoreProductItems { get; set; } = new List<StoreProductItem>();
}
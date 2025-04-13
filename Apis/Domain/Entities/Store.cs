namespace Domain.Entities;

public class Store : BaseFullEntity
{
    public string Name { get; set; } = null!;
    public string? Infomation { get; set; }
    public string AvatarPath { get; set; }
    public string? AdditionalInfo { get; set; }
    public bool IsBanned { get; set; }
    public bool IsActive { get; set; }
    public int IsVerified { get; set; }

    // Navigation properties
    public virtual ICollection<StoreUser> StoreUsers { get; set; } = new List<StoreUser>(); //Employees
    
}
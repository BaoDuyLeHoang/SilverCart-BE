namespace Domain.Entities;

public class StoreUserRole
{
    // Navigation properties
    public int UserId { get; set; }
    public virtual StoreUser StoreUser { get; set; } = null!;
    public int RoleId { get; set; }
    public virtual StoreRole Role { get; set; } = null!;
}
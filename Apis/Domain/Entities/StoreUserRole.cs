namespace Domain.Entities;

public class StoreUserRole : BaseEntity
{
    // Navigation properties
    public Guid UserId { get; set; }
    public virtual StoreUser StoreUser { get; set; } = null!;
    public Guid RoleId { get; set; }
    public virtual StoreRole Role { get; set; } = null!;
}
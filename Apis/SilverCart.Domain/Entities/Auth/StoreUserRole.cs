using SilverCart.Domain.Common.Interfaces;

namespace SilverCart.Domain.Entities.Auth;

public class StoreUserRole : AuditableEntity
{
    // Navigation properties
    public Guid UserId { get; set; }
    public virtual StoreUser StoreUser { get; set; } = null!;
    public Guid RoleId { get; set; }
    public virtual StoreRole Role { get; set; } = null!;
}
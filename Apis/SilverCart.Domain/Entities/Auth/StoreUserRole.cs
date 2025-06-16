using SilverCart.Domain.Common.Interfaces;

namespace SilverCart.Domain.Entities;

public class StoreUserRole : IAuditableEntity
{
    // Navigation properties
    public Guid UserId { get; set; }
    public virtual StoreUser StoreUser { get; set; } = null!;
    public Guid RoleId { get; set; }
    public virtual StoreRole Role { get; set; } = null!;
    public DateTime? CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public DateTime? DeletionDate { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid? ModificationById { get; set; }
    public Guid? DeleteById { get; set; }
}
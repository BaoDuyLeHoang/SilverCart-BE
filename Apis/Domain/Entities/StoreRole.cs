namespace Domain.Entities;

public class StoreRole : BaseRole
{
    // Navigation properties
    public virtual ICollection<StoreUserRole> StoreUserRoles { get; set; } = new HashSet<StoreUserRole>();
    
}
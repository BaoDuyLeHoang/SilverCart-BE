namespace Domain.Entities;

public class StoreUser : BaseUser
{
    // Navigation properties
    public virtual ICollection<StoreUserRole> StoreUserRoles { get; set; } = new HashSet<StoreUserRole>();
    public virtual ICollection<ScheduledTask> ScheduledTasks { get; set; } = new HashSet<ScheduledTask>();
}
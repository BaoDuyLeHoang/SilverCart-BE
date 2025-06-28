
namespace SilverCart.Domain.Entities;


public class StoreUser : BaseUser
{
    public Guid? StoreId { get; set; }
    public Store? Store { get; set; }
    // Navigation properties
    public virtual ICollection<ScheduledTask> ScheduledTasks { get; set; } = new HashSet<ScheduledTask>();
}
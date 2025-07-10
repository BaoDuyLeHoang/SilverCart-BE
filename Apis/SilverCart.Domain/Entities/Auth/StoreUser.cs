using SilverCart.Domain.Commons.Enums;

namespace SilverCart.Domain.Entities;


public class StoreUser : BaseUser
{

    // Navigation properties
    public virtual ICollection<ScheduledTask>? ScheduledTasks { get; set; } = new HashSet<ScheduledTask>();
}
using SilverCart.Domain.Commons.Entities;
using SilverCart.Domain.Entities.Auth;

namespace SilverCart.Domain.Entities.Stores;

public class StoreRole : BaseRole
{
    // Navigation properties
    public virtual ICollection<StoreUserRole> StoreUserRoles { get; set; } = new HashSet<StoreUserRole>();

}
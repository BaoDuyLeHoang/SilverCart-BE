using SilverCart.Domain.Commons.Entities;

namespace SilverCart.Domain.Entities.Auth;

public class CustomerRole : BaseRole
{
    //navigation properties
    public virtual ICollection<CustomerUser> Customers { get; set; } = new HashSet<CustomerUser>();
}
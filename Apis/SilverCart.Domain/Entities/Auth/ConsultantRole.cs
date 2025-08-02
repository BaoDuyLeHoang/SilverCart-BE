using SilverCart.Domain.Commons.Entities;

namespace SilverCart.Domain.Entities.Auth;

public class ConsultantRole : BaseRole
{
    //navigation properties
    public virtual ICollection<ConsultantUser> Customers { get; set; } = new HashSet<ConsultantUser>();
}
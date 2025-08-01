using SilverCart.Domain.Commons.Enums;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Chat;

namespace SilverCart.Domain.Entities;


public class StoreUser : BaseUser
{

    // Navigation properties
    public Guid? StoreId { get; set; }
    public virtual Store? Store { get; set; }
    public virtual ICollection<StoreUserRole>? StoreUserRoles { get; set; } = new HashSet<StoreUserRole>();
    public virtual ICollection<ConversationMember> ConversationMemberships { get; set; } = new HashSet<ConversationMember>();
}
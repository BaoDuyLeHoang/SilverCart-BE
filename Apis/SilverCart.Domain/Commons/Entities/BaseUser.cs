using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Identity;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities.Chat;

namespace SilverCart.Domain.Entities
{
    public class BaseUser : IdentityUser<Guid>, IBaseEntity, IAuditableEntity
    {
        public string FullName { get; set; }
        public OTPData? OTP { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? ModificationById { get; set; }
        public Guid? DeleteById { get; set; }
        public Guid? StoreId { get; set; }
        public Store? Store { get; set; }
        public virtual ICollection<Conversation> ConversationsAsUser1 { get; set; } = new List<Conversation>();
        public virtual ICollection<Conversation> ConversationsAsUser2 { get; set; } = new List<Conversation>();
        //public virtual ICollection<StoreUser> StoreUsers { get; set; } = new List<StoreUser>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public string? RefreshToken { get; set; }
    }
}

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
        public string Gender { get; set; } = "Other";
        public virtual ICollection<SavedAddress> Addresses { get; set; } = new HashSet<SavedAddress>();
        public string? RefreshToken { get; set; }
        public virtual ICollection<ConversationMember> ConversationMemberships { get; set; } = new HashSet<ConversationMember>();

        public bool IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? ModificationById { get; set; }
        public Guid? DeleteById { get; set; }
        public bool IsHardDelete { get; set; } = false;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using Domain.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public abstract class BaseUser : IdentityUser<Guid>, IBaseEntity,IDateTracking,IUserTracking
    {
        [NotMapped]
        public OTPData? OTP { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? ModificationById { get; set; }
        public Guid? DeleteById { get; set; }
    };

}
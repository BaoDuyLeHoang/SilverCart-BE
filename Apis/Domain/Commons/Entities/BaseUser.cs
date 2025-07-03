using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using Domain.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public abstract class BaseUser : IdentityUser<Guid>, IBaseEntity,IDateTracking,IUserTracking
    {
        public OTPData? OTP { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? ModificationById { get; set; }
        public Guid? DeleteById { get; set; }
    };

    public class OTPData
    {
        public string Code { get; set; } = string.Empty;
        public DateTime ExpirationTime { get; set; }
        public bool IsUsed { get; set; } = false;

        public static OTPData Init(string code, int days) => new OTPData()
        {
            Code = code,
            ExpirationTime = DateTime.UtcNow.AddDays(days),
            IsUsed = false
        };
    }
}
using System.ComponentModel.DataAnnotations;
using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public abstract class BaseUser : BaseFullEntity
    {
        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        
        public string RefreshToken {get; set;}
        
        public DateTime SignInTime {get; set;}
        
    }
}

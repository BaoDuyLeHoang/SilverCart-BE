using System.ComponentModel.DataAnnotations;
using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public abstract class BaseUser : BaseFullEntity
    {
        [EmailAddress] public string Email { get; set; }
        [Phone] public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime SignInTime { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsVerified { get; set; } = true;
    }
}
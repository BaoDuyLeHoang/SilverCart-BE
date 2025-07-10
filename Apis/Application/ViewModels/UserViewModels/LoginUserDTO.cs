using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.ViewModels.UserViewModels
{
    public class LoginUserDTO
    {
        [EmailAddress] public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserDTO
    {
        [EmailAddress] public string? Email { get; set; }
        [Phone] public string? Phone { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
    public class UpdateUserDTO
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ChangePasswordDTO
    {
        [EmailAddress] public string? Email { get; set; }
        [Phone] public string? Phone { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
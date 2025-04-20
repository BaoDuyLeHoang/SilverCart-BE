using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.ViewModels.UserViewModels
{
    public class UserLoginDTO
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
        [EmailAddress] public string? Email { get; set; }
        [Phone] public string? Phone { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using SilverCart.Domain.Entities;

namespace SilverCart.Application.ViewModels.UserViewModels
{
    public class LoginUserDTO
    {
        [EmailAddress] public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public class RegisterUserDTO
    {
        [EmailAddress] public string Email { get; set; }
        [Phone] public string? Phone { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public string? StreetAddress { get; set; }
        public string? WardCode { get; set; }
        public int? DistrictId { get; set; }
        public string? ToDistrictName { get; set; }
        public string? ToProvinceName { get; set; }
        public bool IsPhoneRegistration { get; set; }
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
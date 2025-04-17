using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.ViewModels.UserViewModels
{
    public class UserLoginDTO
    {
        [EmailAddress] public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserRegisterDTO : BaseUser
    {
        [EmailAddress] public string Email { get; set; }
        public string Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.UserViewModels
{
    public class UserLoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

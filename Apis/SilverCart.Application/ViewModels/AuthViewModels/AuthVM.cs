using System.ComponentModel.DataAnnotations;

namespace Infrastructures.ViewModels.AuthViewModels;

public class AuthVM
{
    public class SignIn
    {
        public class Mail
        {
            [EmailAddress] public string Email { get; set; }
            public string Password { get; set; }
        }

        public class Phone
        {
            [Phone] public string PhoneNumber { get; set; }
            public string Password { get; set; }
        }
    }
}

public class AuthSignInVM
{
    public class WithMail : AuthSignInVM
    {
        [EmailAddress] public string Email { get; set; }
        public string Password { get; set; }
    }

    public class WithPhone : AuthSignInVM
    {
        [Phone] public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}

public class AuthSignUpVM
{
    [EmailAddress] public string Email { get; set; }
    [Phone] public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
}
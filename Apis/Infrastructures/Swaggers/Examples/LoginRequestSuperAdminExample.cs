using Application.Commons;
using Application.ViewModels.UserViewModels;
using Swashbuckle.AspNetCore.Filters;

namespace Infrastructures.Swaggers.Examples;

public class LoginRequestSuperAdminExample : IExamplesProvider<UserLoginDTO>
{
    private readonly AppConfiguration _configuration;

    public LoginRequestSuperAdminExample(AppConfiguration configuration)
    {
        _configuration = configuration;
    }

    public UserLoginDTO GetExamples()
    {
        return new UserLoginDTO()
        {
            Email = _configuration.SuperAdmin.Email,
            Password = _configuration.SuperAdmin.Password
        };
    }
}
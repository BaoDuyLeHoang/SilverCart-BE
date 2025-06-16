//using SilverCart.Application.Commons;
//using SilverCart.Application.ViewModels.UserViewModels;
//using SilverCart.Infrastructure.Commons;
//using Swashbuckle.AspNetCore.Filters;

//namespace Infrastructures.Swaggers.Examples;

//public class LoginRequestSuperAdminExample : IExamplesProvider<LoginUserDTO>
//{
//    private readonly AppConfiguration _configuration;

//    public LoginRequestSuperAdminExample(AppConfiguration configuration)
//    {
//        _configuration = configuration;
//    }

//    public LoginUserDTO GetExamples()
//    {
//        return new LoginUserDTO()
//        {
//            Email = _configuration.SuperAdmin.Email,
//            Password = _configuration.SuperAdmin.Password
//        };
//    }
//}
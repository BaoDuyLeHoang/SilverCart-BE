// Application/Interfaces/IUserService.cs
using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<TokenResponseDTO> LoginAsync(UserLoginDTO userObject);
        Task RegisterAsync(UserLoginDTO userObject);
        Task<string> VerifyEmailAsync(string token, string email);
        Task<TokenResponseDTO> RefreshTokenAsync(string refreshToken);
        Task RevokeTokenAsync(string refreshToken);
        Task<BaseUser> CreateUser(UserRegisterDTO userRegisterDTO, int roleId);
        Task<TokenResponseDTO> LoginSuperAdmin(UserLoginDTO loginObject);
        Task CreateSuperAdminIfNotExists();
    }
}
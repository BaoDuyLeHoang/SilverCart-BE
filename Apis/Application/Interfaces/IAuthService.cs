using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<Result<TokenResponseDTO>> LoginSuperAdmin(LoginUserDTO loginDTO);
    Task<Result<TokenResponseDTO>> LoginAsync(LoginUserDTO loginUserObject);
    Task<Result<string>> RegisterAsync(RegisterUserDTO registerUserObject);
    Task<Result<string>> VerifyEmailAsync(string token, string email);
    Task<Result<string>> VerifyOTPAsync(string otp, string phoneNumber);
    Task<Result<TokenResponseDTO>> RefreshTokenAsync(string refreshToken);
    Task<Result> RevokeTokenAsync(string refreshToken);
    Task<Result<BaseUser>> CreateUser(RegisterUserDTO registerUserDTO, int roleId);
}
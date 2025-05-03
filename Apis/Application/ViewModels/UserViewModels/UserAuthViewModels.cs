// Application/ViewModels/UserViewModels/AuthDTOs.cs

using Domain.Entities;

namespace Application.ViewModels.UserViewModels
{
    public class TokenResponseDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
    public class RefreshTokenDTO
    {
        public string RefreshToken { get; set; }
    }
    
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
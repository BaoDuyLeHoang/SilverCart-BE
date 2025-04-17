// Application/Interfaces/IEmailService.cs

namespace Application.Interfaces
{
    public interface IEmailService
    {
        Task SendVerificationEmail(string email, string token);
        Task SendPasswordResetEmail(string email, string token);
    }
}
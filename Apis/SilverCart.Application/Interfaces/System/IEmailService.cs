// SilverCart.Infrastructureerfaces/IEmailService.cs

namespace SilverCart.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendVerificationEmail(string email, string token);
        Task SendPasswordResetEmail(string email, string token);
        Task SendEmailAsync(string email, string subject, string message);
    }
}

using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
using SilverCart.Application.Interfaces;
using SilverCart.Infrastructure.Commons;

namespace SilverCart.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly AppConfiguration _configuration;

        public EmailService(ILogger<EmailService> logger, AppConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task SendVerificationEmail(string email, string token)
        {
            var verificationLink =
                $"{_configuration.ApplicationUrl}/auth/verify-email?token={WebUtility.UrlEncode(token)}&email={WebUtility.UrlEncode(email)}";
            var subject = "Xác thực email";
            var body = $"Xác thực email bằng cách nhấp vào liên kết này: <a href='{verificationLink}'>Xác thực email</a>";

            SendEmailAsync(email, subject, body).ConfigureAwait(false);
        }

        public async Task SendPasswordResetEmail(string email, string token)
        {
            var resetLink =
                $"{_configuration.ApplicationUrl}/auth/reset-password?token={WebUtility.UrlEncode(token)}&email={WebUtility.UrlEncode(email)}";
            var subject = "Đặt lại mật khẩu";
            var body = $"Đặt lại mật khẩu bằng cách nhấp vào liên kết này: <a href='{resetLink}'>Đặt lại mật khẩu</a>";

            await SendEmailAsync(email, subject, body);
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_configuration.EmailSettings.From),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                using (var client = new SmtpClient(_configuration.EmailSettings.SmtpServer))
                {
                    client.Port = _configuration.EmailSettings.Port;
                    client.Credentials = new NetworkCredential(
                        _configuration.EmailSettings.Username,
                        _configuration.EmailSettings.Password);
                    client.EnableSsl = true;

                    client.SendMailAsync(mailMessage).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending email to {to}");
                // In development, just log the verification link
                _logger.LogInformation($"Verification link for {to}: {body}");
            }
        }
    }
}
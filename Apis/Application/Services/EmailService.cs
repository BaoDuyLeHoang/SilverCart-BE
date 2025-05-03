// Application/Services/EmailService.cs

using Application.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
using Application.Commons;

namespace Application.Services
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
            var subject = "Verify Your Email";
            var body = $"Please verify your email by clicking this link: <a href='{verificationLink}'>Verify Email</a>";

            SendEmailAsync(email, subject, body).ConfigureAwait(false);
        }

        public async Task SendPasswordResetEmail(string email, string token)
        {
            var resetLink =
                $"{_configuration.ApplicationUrl}/auth/reset-password?token={WebUtility.UrlEncode(token)}&email={WebUtility.UrlEncode(email)}";
            var subject = "Reset Your Password";
            var body = $"Reset your password by clicking this link: <a href='{resetLink}'>Reset Password</a>";

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
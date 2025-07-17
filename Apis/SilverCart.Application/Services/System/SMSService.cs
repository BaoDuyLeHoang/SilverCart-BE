using Infrastructures.Interfaces;
using Infrastructures.Interfaces.System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Interfaces.System;

namespace Infrastructures.Services.System;

public class SMSService : ISMSService
{
    private readonly IEmailService? _emailService;
    private readonly ILogger<SMSService> _logger;
    private readonly IWebHostEnvironment _env;

    public SMSService(IEmailService? emailService, ILogger<SMSService> logger, IWebHostEnvironment env)
    {
        // Use email service in development
        _emailService = env.IsDevelopment() ? emailService : null;
        _logger = logger;
        _env = env;
    }

    public async Task SendSMS(string phoneNumber, string message)
    {
        if (_env.IsDevelopment())
        {
            _logger.LogInformation($"Sending email message to {phoneNumber}");
            _emailService?.SendEmailAsync(phoneNumber, $"SMS Message {phoneNumber}", message)
                .ConfigureAwait(false);
        }

        // Implement your SMS sending logic here
        // This is a placeholder for the actual SMS sending code
        if (_env.IsProduction())
        {
            try
            {
                // // Assuming stringeeService is injected and available
                // await stringeeService.SendSmsAsync(phoneNumber, message);
                _logger.LogInformation($"SMS sent successfully to {phoneNumber}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to send SMS to {phoneNumber}");
            }
        }
    }
}
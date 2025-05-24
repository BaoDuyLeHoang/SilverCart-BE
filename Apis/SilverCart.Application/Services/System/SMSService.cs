using SilverCart.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SilverCart.Application.Interfaces;

namespace SilverCart.Application.Utils;

public class SMSService : ISMSService
{
    private readonly IEmailService? _emailService;
    private readonly ILogger<SMSService> _logger;
    private readonly IWebHostEnvironment _env;

    public SMSService(IEmailService? emailService, ILogger<SMSService> logger, IWebHostEnvironment env)
    {
        // Use email service in development
        _emailService = env.IsDevelopment() ? emailService : null;

        _emailService = emailService;
        _logger = logger;
        _env = env;
    }

    public async Task SendOTPSMS(string phoneNumber, string otp)
    {
        if (_env.IsDevelopment())
        {
            _logger.LogInformation($"Sending emailed OTP to {phoneNumber}: {otp}");
            _emailService?.SendEmailAsync(phoneNumber, "Your OTP Code", $"Your OTP code is: {otp}")
                .ConfigureAwait(false);
        }

        // Implement your SMS sending logic here
        // This is a placeholder for the actual SMS sending code
        if (_env.IsProduction())
        {
            Console.WriteLine($"Sending SMS to {phoneNumber}");
        }
    }


}

public interface ISMSService
{
    Task SendOTPSMS(string phoneNumber, string otp);
}
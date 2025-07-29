using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Application.Utils;
using SilverCart.Application.Interfaces.System;

namespace Infrastructures;

public sealed record ForgotPasswordCommand(string Email) : IRequest<string>;

public sealed record ForgotPasswordResponse(string Email) : IRequest<bool>;

public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand, string>
{
    private readonly UserManager<BaseUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly ISMSService _smsService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentTime _currentTime;

    public ForgotPasswordHandler(
        UserManager<BaseUser> userManager,
        IEmailService emailService,
        ISMSService smsService,
        IUnitOfWork unitOfWork,
        ICurrentTime currentTime)
    {
        _userManager = userManager;
        _emailService = emailService;
        _smsService = smsService;
        _unitOfWork = unitOfWork;
        _currentTime = currentTime;
    }

    public async Task<string> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        // Determine if input is email or phone
        bool isEmail = request.Email.Contains('@');

        BaseUser? user;

        user = await HandleEmail(request, cancellationToken);
        return $"Một link reset đã được gửi đến email: {user?.Email}";
    }

    public async Task<BaseUser> HandleEmail(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new AppExceptions("Không tìm thấy tài khoản liên kết với email này.");
        }
        var roles = await _userManager.GetRolesAsync(user);
        if (roles.Contains("Guardian") || roles.Contains("Elder"))
        {
            throw new AppExceptions("Không thể đặt lại mật khẩu cho tài khoản Guardian hoặc Elder.");
        }
        // Generate reset token
        string token = await _userManager.GeneratePasswordResetTokenAsync(user);

        // Send email with token
        await _emailService.SendPasswordResetEmail(user.Email!, token);
        return user;
    }
    // remove
    private async Task<BaseUser> HandlePhone(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        // Find by phone
        var user = _userManager.Users.FirstOrDefault(u => u.PhoneNumber == request.Email);
        if (user == null)
        {
            throw new AppExceptions("No user associated with this phone number.");
        }

        // Generate OTP
        string otp = StringUtils.GenerateOTPCode();

        // Store OTP for the user
        user.OTP = new OTPData()
        {
            Code = otp,
            IsUsed = false,
            ExpirationTime = _currentTime.GetCurrentTime().AddMinutes(15) // 15 minutes validity
        };

        await _userManager.UpdateAsync(user);
        await _unitOfWork.SaveChangeAsync();

        // Send SMS with OTP
        await _smsService.SendSMS(user.PhoneNumber, otp);
        return user;
    }
}
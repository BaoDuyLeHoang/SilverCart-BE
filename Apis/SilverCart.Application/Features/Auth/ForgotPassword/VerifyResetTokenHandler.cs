using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;

namespace Infrastructures;

public sealed record VerifyResetTokenCommand(string EmailOrPhone, string Token) : IRequest<bool>;

public class VerifyResetTokenHandler : IRequestHandler<VerifyResetTokenCommand, bool>
{
    private readonly UserManager<BaseUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentTime _currentTime;

    public VerifyResetTokenHandler(
        UserManager<BaseUser> userManager,
        IUnitOfWork unitOfWork,
        ICurrentTime currentTime)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _currentTime = currentTime;
    }

    public async Task<bool> Handle(VerifyResetTokenCommand request, CancellationToken cancellationToken)
    {
        // Determine if input is email or phone
        bool isEmail = request.EmailOrPhone.Contains('@');

        if (isEmail)
        {
            await HandleEmailVerification(request);
        }
        else
        {
            await HandlePhoneVerification(request);
        }

        return true;
    }

    private async Task HandleEmailVerification(VerifyResetTokenCommand request)
    {
        var user = await _userManager.FindByEmailAsync(request.EmailOrPhone);
        if (user == null)
        {
            throw new AppExceptions("No user associated with this email.", 404);
        }

        // Verify token
        bool isValid = await _userManager.VerifyUserTokenAsync(
            user,
            _userManager.Options.Tokens.PasswordResetTokenProvider,
            "ResetPassword",
            request.Token);

        if (!isValid)
        {
            throw new AppExceptions("Invalid or expired token.", 400);
        }
    }

    private async Task HandlePhoneVerification(VerifyResetTokenCommand request)
    {
        var user = _userManager.Users.FirstOrDefault(u => u.PhoneNumber == request.EmailOrPhone);
        if (user == null)
        {
            throw new AppExceptions("No user associated with this phone number.", 404);
        }

        // Verify OTP
        if (user.OTP == null || user.OTP.Code != request.Token)
        {
            throw new AppExceptions("Invalid OTP.", 400);
        }

        if (user.OTP.IsUsed)
        {
            throw new AppExceptions("OTP has already been used.", 400);
        }

        if (user.OTP.ExpirationTime < _currentTime.GetCurrentTime())
        {
            throw new AppExceptions("OTP has expired.", 400);
        }

        // Mark OTP as verified but not used yet
        user.OTP.IsUsed = true;
        await _userManager.UpdateAsync(user);
        await _unitOfWork.SaveChangeAsync();
    }
}
using System.Collections.Immutable;
using FluentValidation;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;

namespace Infrastructures;

public sealed record ResetPasswordCommand(string EmailOrPhone, string Token, string NewPassword) : IRequest<bool>;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, bool>
{
    private readonly UserManager<BaseUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentTime _currentTime;

    public ResetPasswordHandler(
        UserManager<BaseUser> userManager,
        IUnitOfWork unitOfWork,
        ICurrentTime currentTime)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _currentTime = currentTime;
    }

    public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        // Determine if input is email or phone
        bool isEmail = request.EmailOrPhone.Contains('@');

        BaseUser user;
        if (isEmail)
        {
            user = await _userManager.FindByEmailAsync(request.EmailOrPhone);
            AppExceptions.ThrowIfNotFound(user, "No user associated with this email.");
            // Reset password with token
            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToImmutableList();
                throw new AppExceptions("Failed to reset password", errors);
            }
        }
        else
        {
            // Find by phone
            user = _userManager.Users.FirstOrDefault(u => u.PhoneNumber == request.EmailOrPhone);
            AppExceptions.ThrowIfNotFound(user, "No user associated with this email.");

            // Verify OTP again
            AppExceptions.ThrowIfTrue(user.OTP.Code == request.Token, "Invalid OTP.");
            AppExceptions.ThrowIfTrue(user.OTP.IsUsed, "OTP has not been used.");
            AppExceptions.ThrowIfTrue(user.OTP.ExpirationTime < _currentTime.GetCurrentTime(), "OTP has expired.");
            AppExceptions.ThrowIfTrue(!user.OTP.IsUsed, "OTP has not been verified.");

            // Reset password directly
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new AppExceptions($"Failed to reset password: {errors}", 400);
            }

            // Mark OTP as used
            user.OTP.IsUsed = true;
            await _userManager.UpdateAsync(user);
            await _unitOfWork.SaveChangeAsync();
        }

        return true;
    }
}

public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.EmailOrPhone)
            .NotEmpty()
            .WithMessage("Email or phone number is required.");

        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("Token is required.");

        RuleFor(x => x.NewPassword)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
            .WithMessage(
                "Password must contain at least 8 characters, including 1 uppercase letter, 1 lowercase letter, 1 number, and 1 special character.");
    }
}
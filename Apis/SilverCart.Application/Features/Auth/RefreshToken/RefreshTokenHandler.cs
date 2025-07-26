using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;

namespace Infrastructures;

public sealed record RefreshTokenCommand(string RefreshToken) : IRequest<RefreshTokenResponse>;
public record RefreshTokenResponse(string AccessToken, string RefreshToken, DateTime Expiration);
public class RefreshTokenHandler(UserManager<BaseUser> userManager, IJwtTokenGenerator jwtTokenGenerator, ICurrentTime currentTime) : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly UserManager<BaseUser> _userManager = userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly ICurrentTime _currentTime = currentTime;

    public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.RefreshToken))
        {
            throw new AppExceptions("Refresh token không hợp lệ");
        }

        var user = _userManager.Users.FirstOrDefault(u => u.RefreshToken == request.RefreshToken);
        if (user == null)
        {
            throw new AppExceptions("Refresh token không hợp lệ");
        }

        var tokenCreationTime = user.ModificationDate ?? user.CreationDate ?? _currentTime.GetCurrentTime();
        if (tokenCreationTime.AddDays(30) < _currentTime.GetCurrentTime())
        {
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
            throw new AppExceptions("Refresh token đã hết hạn");
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var userRole = userRoles.FirstOrDefault() ?? "Customer";

        var newAccessToken = _jwtTokenGenerator.GenerateJwtToken(user, userRole);
        var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.ModificationDate = _currentTime.GetCurrentTime();
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new AppExceptions("Thất bại khi đổi refresh token");
        }

        return new RefreshTokenResponse(
            newAccessToken,
            newRefreshToken,
            _currentTime.GetCurrentTime().AddMinutes(30)
        );
    }
}

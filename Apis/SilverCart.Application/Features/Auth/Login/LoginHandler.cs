using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;

namespace Infrastructures;

public sealed record LoginUserCommand(string Email, string Password) : IRequest<LoginUserResponse>;
public record LoginUserResponse(Guid UserId, string Role, string AccessToken, string RefreshToken, DateTime Expiration);

public class LoginHandler(
    UserManager<BaseUser> userManager,
    IJwtTokenGenerator jwtTokenGenerator,
    ICurrentTime currentTime) : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
    private readonly UserManager<BaseUser> _userManager = userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly ICurrentTime _currentTime = currentTime;

    public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email)
        ?? await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.Email);
        if (user == null)
        {
            throw new AppExceptions("Không tìm thấy tài khoản");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordValid)
        {
            throw new AppExceptions("Mật khẩu không chính xác");
        }

        var userRoles = await _userManager.GetRolesAsync(user);
        var userRole = userRoles.FirstOrDefault();
        if (userRole == null)
        {
            throw new AppExceptions("Không tìm thấy role của người dùng");
        }

        var token = _jwtTokenGenerator.GenerateJwtToken(user, userRole);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        await _userManager.UpdateAsync(user);

        return new LoginUserResponse(user.Id, userRole, token, refreshToken,
            _currentTime.GetCurrentTime().AddMinutes(30));
    }
}
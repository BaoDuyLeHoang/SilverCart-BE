using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Auth.Login
{
    public sealed record ElderLoginCommand(string Token) : IRequest<ElderLoginResponse>;
    public sealed record ElderLoginResponse(LoginUserResponse LoginUserResponse);
    public class ElderLoginHandler(IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork, UserManager<BaseUser> userManager) : IRequestHandler<ElderLoginCommand, ElderLoginResponse>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<BaseUser> _userManager = userManager;
        public async Task<ElderLoginResponse> Handle(ElderLoginCommand request, CancellationToken cancellationToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(request.Token);

            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim == null)
            {
                throw new AppExceptions("Token không hợp lệ: thiếu UserId.");
            }

            if (!Guid.TryParse(userIdClaim.Value, out var dependentUserId))
            {
                throw new AppExceptions("UserId trong token không hợp lệ.");
            }

            var dependentUser = await _userManager.FindByIdAsync(dependentUserId.ToString());
            if (dependentUser == null)
            {
                throw new AppExceptions("Không tìm thấy người dùng phụ thuộc.");
            }

            var roles = await _userManager.GetRolesAsync(dependentUser);
            var role = roles.FirstOrDefault() ?? "Dependent";

            var newAccessToken = _jwtTokenGenerator.GenerateJwtToken(dependentUser, role);
            var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

            var loginUserResponse = new LoginUserResponse(dependentUser.Id, role, newAccessToken, refreshToken, DateTime.UtcNow.AddMinutes(15));
            return new ElderLoginResponse(loginUserResponse);
        }
    }
}
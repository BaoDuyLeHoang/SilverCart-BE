using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures
{
    public sealed record RegisterAsGuardianCommand(Guid UserId) : IRequest<Guid>;
    public class RegisterAsGuardianHandler : IRequestHandler<RegisterAsGuardianCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<BaseUser> _userManager;
        private readonly ICurrentTime _currentTime;
        public RegisterAsGuardianHandler(IUnitOfWork unitOfWork, UserManager<BaseUser> userManager, ICurrentTime currentTime)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _currentTime = currentTime;
        }
        public async Task<Guid> Handle(RegisterAsGuardianCommand request, CancellationToken cancellationToken)
        {
            var checkUser = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);
            if (checkUser == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                return checkUser.Id;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Users.Queries.GetDetailsUser
{
    public sealed record GetDetailUserQuery(Guid Id) : IRequest<GetDetailUserResponse>;
    public record GetDetailUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate);
    public class GetDetailUserQueryHandler(IUnitOfWork unitOfWork, UserManager<BaseUser> userManager) : IRequestHandler<GetDetailUserQuery, GetDetailUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<BaseUser> _userManager = userManager;
        public async Task<GetDetailUserResponse> Handle(GetDetailUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new AppExceptions("User not found");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault() ?? "Unknown";
            return new GetDetailUserResponse(user.Id, user.FullName, user.Email, user.PhoneNumber, role, user.CreationDate.Value);
        }
    }
}
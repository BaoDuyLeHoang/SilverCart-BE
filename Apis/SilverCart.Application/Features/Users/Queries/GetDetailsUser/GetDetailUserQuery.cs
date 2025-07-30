using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Users.Queries.GetDetailsUser
{
    public sealed record GetDetailUserQuery(Guid Id) : IRequest<GetDetailUserResponse>;
    public record GetDetailUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate);
    public class GetDetailUserQueryHandler(IUnitOfWork unitOfWork, UserManager<BaseUser> userManager, IClaimsService claimsService) : IRequestHandler<GetDetailUserQuery, GetDetailUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<BaseUser> _userManager = userManager;
        private readonly IClaimsService _claimsService = claimsService;
        public async Task<GetDetailUserResponse> Handle(GetDetailUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new AppExceptions("Không tìm thấy người dùng");

            var currentUserId = _claimsService.CurrentUserId;
            var currentUserRole = _claimsService.CurrentRole;

            var canView = false;

            if (request.Id == currentUserId || currentUserRole == RoleEnum.SuperAdmin || currentUserRole == RoleEnum.Admin)
            {
                canView = true;
            }
            else if (currentUserRole == RoleEnum.Guardian)
            {
                // kiểm tra xem user được xem có phải là Elder thuộc Guardian này không
                var IsFamily = await _unitOfWork.GuardianUserRepository.IsUserInMyFamilyAsync(request.Id, currentUserId);
                var IsMyGuardian = await _unitOfWork.DependentUserRepository.IsUserInMyFamilyAsync(currentUserId, request.Id);
                if (IsFamily || IsMyGuardian) canView = true;
            }
            else if (currentUserRole == RoleEnum.ShopOwner)
            {
                // kiểm tra xem user đó có phải là nhân viên hoặc consultant của StoreOwner này không
                var isMyStaff = await _unitOfWork.StoreRepository.IsUserInMyStoreAsync(request.Id, currentUserId);
                if (isMyStaff) canView = true;
            }

            if (!canView)
                throw new AppExceptions("Bạn không có quyền xem thông tin người dùng này");

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault() ?? "Unknown";

            return new GetDetailUserResponse(user.Id, user.FullName, user.Email, user.PhoneNumber, role, user.CreationDate.Value);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Users.Queries.GetDetailsUser
{
    public sealed record GetDetailUserQuery(Guid Id) : IRequest<GetDetailUserResponse>;

    // Base response class
    public record GetBaseUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate);

    // Inherited response for dependent users
    public record GetDependentUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate,
        DateTime? DateOfBirth, string? Relationship, string? MedicalNotes, decimal? MonthlySpendingLimit,
        Guid? GuardianId, string? GuardianName) : GetBaseUserResponse(Id, FullName, Email, Phone, Role, CreationDate);

    public record GetGuardianUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate) : GetBaseUserResponse(Id, FullName, Email, Phone, Role, CreationDate);
    public record GetConsultantUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate, string Specialization, string Biography, string AvatarPath, string ExpertiseArea) : GetBaseUserResponse(Id, FullName, Email, Phone, Role, CreationDate);
    public record GetStoreUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate, string StoreName, string StoreAddress, string StorePhone) : GetBaseUserResponse(Id, FullName, Email, Phone, Role, CreationDate);
    public record GetAdminUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate) : GetBaseUserResponse(Id, FullName, Email, Phone, Role, CreationDate);

    // Main response that can be any user type
    public record GetDetailUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate,
        string UserType, object? AdditionalData = null);

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
            var isCustomerRole = currentUserRole == RoleEnum.Guardian || currentUserRole == RoleEnum.DependentUser;

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

            // Determine user type and additional data
            string userType = "BaseUser";
            object? additionalData = null;

            if (user is DependentUser dependentUser)
            {
                userType = "DependentUser";
                additionalData = new GetDependentUserResponse(
                    dependentUser.Id,
                    dependentUser.FullName,
                    dependentUser.Email,
                    dependentUser.PhoneNumber,
                    role,
                    dependentUser.CreationDate.Value,
                    dependentUser.DateOfBirth,
                    dependentUser.Relationship,
                    dependentUser.MedicalNotes,
                    dependentUser.MonthlySpendingLimit,
                    dependentUser.GuardianId,
                    dependentUser.Guardian?.FullName
                );
            }
            else if (user is GuardianUser guardianUser)
            {
                userType = "GuardianUser";
                additionalData = new GetGuardianUserResponse(
                    guardianUser.Id,
                    guardianUser.FullName,
                    guardianUser.Email,
                    guardianUser.PhoneNumber,
                    role,
                    guardianUser.CreationDate.Value
                );
            }
            else if (user is ConsultantUser consultantUser)
            {
                userType = "ConsultantUser";
                additionalData = new GetConsultantUserResponse(
                    consultantUser.Id,
                    consultantUser.FullName,
                    consultantUser.Email,
                    consultantUser.PhoneNumber,
                    role,
                    consultantUser.CreationDate.Value,
                    consultantUser.Specialization,
                    consultantUser.Biography,
                    consultantUser.AvatarPath,
                    consultantUser.ExpertiseArea
                );
            }
            else if (user is StoreUser storeUser)
            {
                userType = "StoreUser";
                additionalData = new GetStoreUserResponse(
                    storeUser.Id,
                    storeUser.FullName,
                    storeUser.Email,
                    storeUser.PhoneNumber,
                    role,
                    storeUser.CreationDate.Value,
                    storeUser.Store?.Name ?? "",
                    storeUser.Store?.StoreAddress?.StreetAddress ?? "",
                    storeUser.Store?.Phone ?? ""
                );
            }
            else if (user is AdministratorUser adminUser)
            {
                userType = "AdministratorUser";
                additionalData = new GetAdminUserResponse(
                    adminUser.Id,
                    adminUser.FullName,
                    adminUser.Email,
                    adminUser.PhoneNumber,
                    role,
                    adminUser.CreationDate.Value
                );
            }
            else
            {
                // Fallback for any other user type
                additionalData = new GetBaseUserResponse(
                    user.Id,
                    user.FullName,
                    user.Email,
                    user.PhoneNumber,
                    role,
                    user.CreationDate.Value
                );
            }

            return new GetDetailUserResponse(user.Id, user.FullName, user.Email, user.PhoneNumber, role, user.CreationDate.Value, userType, additionalData);
        }
    }
}
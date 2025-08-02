using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Domain.Commons.Entities;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Enums;
using Infrastructures.Commons.Exceptions;

namespace Infrastructures.Features.Users.Queries.GetAllUsers
{
    public sealed record GetAllUsersQuery(PagingRequest? PagingRequest, string? Keyword, RoleEnum[]? Role) : IRequest<PagedResult<GetAllUsersResponse>>;

    // Base response class
    public record GetBaseUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate);

    // Inherited response for dependent users
    public record GetDependentUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate,
        DateTime? DateOfBirth, string? Relationship, string? MedicalNotes, decimal? MonthlySpendingLimit,
        Guid? GuardianId, string? GuardianName) : GetCustomerUserResponse(Id, FullName, Email, Phone, Role, CreationDate);

    public record GetCustomerUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate) : GetBaseUserResponse(Id, FullName, Email, Phone, Role, CreationDate);
    public record GetGuardianUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate) : GetCustomerUserResponse(Id, FullName, Email, Phone, Role, CreationDate);
    public record GetConsultantUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate, string Specialization, string Biography, string AvatarPath, string ExpertiseArea) : GetBaseUserResponse(Id, FullName, Email, Phone, Role, CreationDate);
    public record GetStoreUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate, string StoreName, string StoreAddress, string StorePhone) : GetBaseUserResponse(Id, FullName, Email, Phone, Role, CreationDate);
    public record GetAdminUserResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate) : GetBaseUserResponse(Id, FullName, Email, Phone, Role, CreationDate);

    // Main response that can be any user type
    public record GetAllUsersResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate,
        string UserType, object? AdditionalData = null);

    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, PagedResult<GetAllUsersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<BaseUser> _userManager;
        private readonly IClaimsService _claimsService;
        public GetAllUsersHandler(IUnitOfWork unitOfWork, UserManager<BaseUser> userManager, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _claimsService = claimsService;
        }

        public async Task<PagedResult<GetAllUsersResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            AppExceptions.ThrowIfTrue(_claimsService.CurrentRole == null, "Người dùng chưa đăng nhập");
            AppExceptions.ThrowIfTrue(_claimsService.CurrentRole == RoleEnum.DependentUser, "Người dùng không có quyền truy cập");
            AppExceptions.ThrowIfTrue(_claimsService.CurrentRole == RoleEnum.Guardian, "Người dùng không có quyền truy cập");

            // Validating roles for all users
            var users = await _unitOfWork.UserRepository.FilterUsersWithPaginationAsync(
                keyword: request.Keyword,
                roles: request.Role,
                currentRole: _claimsService.CurrentRole,
                pageNumber: request.PagingRequest?.Page ?? 1,
                pageSize: request.PagingRequest?.PageSize ?? 10
            );

            var userResponses = await MapUsersToResponsesAsync(users.Results);

            return new PagedResult<GetAllUsersResponse>
            {
                Results = userResponses,
                TotalNumberOfRecords = users.TotalNumberOfRecords,
                PageSize = request.PagingRequest?.PageSize ?? 10,
                PageNumber = request.PagingRequest?.Page ?? 1
            };
        }

        private async Task<List<GetAllUsersResponse>> MapUsersToResponsesAsync(List<BaseUser> users)
        {
            var responses = new List<GetAllUsersResponse>();
            foreach (var user in users)
            {
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

                var response = new GetAllUsersResponse(
                    user.Id,
                    user.FullName,
                    user.Email ?? string.Empty,
                    user.PhoneNumber ?? string.Empty,
                    role,
                    user.CreationDate.Value,
                    userType,
                    additionalData
                );
                responses.Add(response);
            }
            return responses;
        }
    }
}

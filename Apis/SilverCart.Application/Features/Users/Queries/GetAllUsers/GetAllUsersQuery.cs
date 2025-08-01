using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Domain.Commons.Entities;
using SilverCart.Domain.Entities;
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
    public record GetAllUsersResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate);
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
            AppExceptions.ThrowIfTrue(_claimsService.CurrentRole == RoleEnum.Customer, "Người dùng không có quyền truy cập");
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
                var response = new GetAllUsersResponse(
                    user.Id,
                    user.FullName,
                    user.Email ?? string.Empty,
                    user.PhoneNumber ?? string.Empty,
                    roles.FirstOrDefault() ?? "Unknown",
                    user.CreationDate.Value
                );
                responses.Add(response);
            }
            return responses;
        }
    }
}

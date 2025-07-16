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

namespace Infrastructures.Features.Users.Queries.GetAllUsers
{
    public sealed record GetAllUsersQuery(PagingRequest? PagingRequest, Guid? Id, string? Keyword) : IRequest<PagedResult<GetAllUsersResponse>>;
    public record GetAllUsersResponse(Guid Id, string FullName, string Email, string Phone, string Role, DateTime CreationDate);
    public class GetAllUsersHandler(IUnitOfWork unitOfWork, UserManager<BaseUser> userManager) : IRequestHandler<GetAllUsersQuery, PagedResult<GetAllUsersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<BaseUser> _userManager = userManager;
        public async Task<PagedResult<GetAllUsersResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersQuery = await _unitOfWork.UserRepository.GetAllAsync();

            var query = usersQuery.AsQueryable();

            if (request.Id.HasValue)
                query = query.Where(u => u.Id == request.Id.Value);
            
            if (!string.IsNullOrWhiteSpace(request.Keyword))
                query = query.Where(u => 
                    u.FullName.Contains(request.Keyword) || 
                    u.Email.Contains(request.Keyword) || 
                    u.PhoneNumber.Contains(request.Keyword)
                );

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
            var pagedUsers = query.ToList();

            var userResponses = new List<GetAllUsersResponse>();
            foreach (var user in pagedUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userResponses.Add(new GetAllUsersResponse(
                    user.Id,
                    user.FullName,
                    user.Email,
                    user.PhoneNumber,
                    roles.FirstOrDefault() ?? "Unknown",
                    user.CreationDate.HasValue ? user.CreationDate.Value : DateTime.MinValue
                ));
            }

            var sortedResult = PaginationHelper<GetAllUsersResponse>.Sorting(sortType, userResponses, sortField);
            return PaginationHelper<GetAllUsersResponse>.Paging(sortedResult, page, pageSize);
        }
    }
}

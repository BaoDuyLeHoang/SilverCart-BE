using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using Infrastructures;
using System.Linq.Expressions;

namespace SilverCart.Application.Features.Users.Queries.GetStoreUser
{
    /// <summary>
    /// Query to get users associated with a store with optional filtering
    /// </summary>
    public sealed record GetStoreUserQuery(
        Guid StoreId,
        Guid? UserId = null,
        string? Keyword = null,
        string? Role = null) : IRequest<List<GetStoreUserResponse>>;

    /// <summary>
    /// Response model for store user query
    /// </summary>
    public record GetStoreUserResponse(
        Guid Id,
        string FullName,
        string Email,
        string Phone,
        string Role);

    /// <summary>
    /// Handler for getting store users with filtering
    /// </summary>
    public class GetStoreUserQueryHandler : IRequestHandler<GetStoreUserQuery, List<GetStoreUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStoreUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetStoreUserResponse>> Handle(GetStoreUserQuery request, CancellationToken cancellationToken)
        {
            // Build base predicate
            Expression<Func<StoreUser, bool>> predicate = x => x.StoreId == request.StoreId;

            // Add user ID filter if provided
            if (request.UserId.HasValue)
            {
                predicate = x => x.StoreId == request.StoreId && x.Id == request.UserId;
            }

            // Get store users
            var query = await _unitOfWork.StoreUserRepository.GetAllAsync(predicate);

            // Apply additional filters
            if (!string.IsNullOrWhiteSpace(request.Keyword))
            {
                var keyword = request.Keyword.ToLower();
                query = query.Where(x =>
                    x.FullName.ToLower().Contains(keyword) ||
                    x.Email.ToLower().Contains(keyword) ||
                    x.PhoneNumber.ToLower().Contains(keyword));
            }

            // Role filtering is not available since StoreUserRoles was removed
            // TODO: Implement role filtering through a different mechanism if needed

            // Execute query and map to response
            var storeUsers = await query.ToListAsync(cancellationToken);

            return storeUsers.Select(x => new GetStoreUserResponse(
                x.Id,
                x.FullName,
                x.Email,
                x.PhoneNumber,
                "Store User" // Default role since StoreUserRoles was removed
            )).ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Features.Users.Queries.GetStoreUser
{
    public sealed record GetStoreUserQuery(Guid? Id, string? FullName, string? Email, string? Phone, string? Role) : IRequest<List<GetStoreUserResponse>>;
    public record GetStoreUserResponse(Guid Id, string FullName, string Email, string Phone, string Roles);
    public class GetStoreUserQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetStoreUserQuery, List<GetStoreUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<List<GetStoreUserResponse>> Handle(GetStoreUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            // var storeUsers = await _unitOfWork.StoreUserRepository.GetAllAsync(
            //     predicate: _ => true,
            //     include: source => source.Include(x => x.User)
            // );
            // if (request.Id.HasValue)
            //     storeUsers = storeUsers.Where(x => x.Id == request.Id.Value);
            // if (!string.IsNullOrWhiteSpace(request.FullName))
            //     storeUsers = storeUsers.Where(x => x.User.FullName.Contains(request.FullName));
            // if (!string.IsNullOrWhiteSpace(request.Email))
            //     storeUsers = storeUsers.Where(x => x.User.Email.Contains(request.Email));
            // if (!string.IsNullOrWhiteSpace(request.Phone))
            //     storeUsers = storeUsers.Where(x => x.User.PhoneNumber.Contains(request.Phone));
            // if (!string.IsNullOrWhiteSpace(request.Role))
            //     storeUsers = storeUsers.Where(x => x.RoleInStore.ToString().Contains(request.Role));
            // return await storeUsers.Select(x => new GetStoreUserResponse(x.Id, x.User.FullName, x.User.Email, x.User.PhoneNumber, x.RoleInStore.ToString())).ToListAsync(cancellationToken);
        }
    }
}
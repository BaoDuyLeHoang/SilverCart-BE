using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;

namespace Infrastructures.Features.Users.Queries.GetDependantUser
{
    public sealed record GetDependentUserQuery(Guid GuardianId) : IRequest<List<GetDependentUserResponse>>;
    public record GetDependentUserResponse(Guid Id, string FullName, string Email, string Phone, DateTime CreatedDate);
    public class GetDependentUserQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetDependentUserQuery, List<GetDependentUserResponse>>
    {
        public async Task<List<GetDependentUserResponse>> Handle(GetDependentUserQuery request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.DependentUserRepository.GetAllAsync(u => u.GuardianId == request.GuardianId);
            if (users == null)
            {
                throw new AppExceptions("No dependent users found");
            }
            return users.Select(u => new GetDependentUserResponse(u.Id, u.FullName, u.Email, u.PhoneNumber, u.CreationDate.Value)).ToList();
        }
    }
}
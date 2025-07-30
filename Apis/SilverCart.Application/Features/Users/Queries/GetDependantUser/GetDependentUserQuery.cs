using Infrastructures.Commons.Exceptions;
using MediatR;

namespace Infrastructures.Features.Users.Queries.GetDependantUser
{
    public sealed record GetDependentUserQuery(Guid GuardianId, string? Keyword = null) : IRequest<List<GetDependentUserResponse>>;
    public sealed record GetDependentUserResponse(Guid Id, string FullName, string Email, string Phone, DateTime CreationDate);
    public class GetDependentUserQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetDependentUserQuery, List<GetDependentUserResponse>>
    {
        public async Task<List<GetDependentUserResponse>> Handle(GetDependentUserQuery request, CancellationToken cancellationToken)
        {
            var keyword = request.Keyword ?? string.Empty;
            var users = await unitOfWork.DependentUserRepository.GetAllAsync(
                predicate: u => u.GuardianId == request.GuardianId &&
                                (u.FullName.Contains(keyword) ||
                                 u.Email.Contains(keyword) ||
                                 u.PhoneNumber.Contains(keyword))
            );

            return users.Select(u => new GetDependentUserResponse(u.Id, u.FullName, u.Email, u.PhoneNumber, u.CreationDate.Value)).ToList();
        }
    }
}
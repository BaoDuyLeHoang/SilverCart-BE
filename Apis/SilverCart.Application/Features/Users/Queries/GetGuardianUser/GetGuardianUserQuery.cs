using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures;

public sealed record GetGuardianUserQuery(Guid? Id, string? FullName, string? Email, string? Phone) : IRequest<List<GetGuardianUserResponse>>;
public record GetGuardianUserResponse(Guid Id, string FullName, string Email, string Phone, List<GetDependentUserResponse> DependentUsers);
public record GetDependentUserResponse(Guid Id, string FullName, string Email, string Phone);
public class GetGuardianUserQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetGuardianUserQuery, List<GetGuardianUserResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<List<GetGuardianUserResponse>> Handle(GetGuardianUserQuery request, CancellationToken cancellationToken)
    {
        var guardianUsers = await _unitOfWork.GuardianUserRepository.GetAllAsync(
            predicate: _ => true,
            include: source => source.Include(x => x.Dependents)
        );

        if (request.Id.HasValue)
            guardianUsers = guardianUsers.Where(u => u.Id == request.Id.Value);
        if (!string.IsNullOrWhiteSpace(request.FullName))
            guardianUsers = guardianUsers.Where(u => u.FullName.Contains(request.FullName));
        if (!string.IsNullOrWhiteSpace(request.Email))
            guardianUsers = guardianUsers.Where(u => u.Email.Contains(request.Email));
        if (!string.IsNullOrWhiteSpace(request.Phone))
            guardianUsers = guardianUsers.Where(u => u.PhoneNumber.Contains(request.Phone));

        return guardianUsers.Select(u => new GetGuardianUserResponse(
            u.Id,
            u.FullName,
            u.Email,
            u.PhoneNumber,
            u.Dependents.Where(d => !d.IsDeleted).Select(d => new GetDependentUserResponse(
                d.Id,
                d.FullName,
                d.Email,
                d.PhoneNumber
            )).ToList()
        )).ToList();
    }
}

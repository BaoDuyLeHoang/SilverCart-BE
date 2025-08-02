using Infrastructures.Commons.Paginations;
using MediatR;
using SilverCart.Domain.Commons.Enums;

namespace Infrastructures.Features.Users.Queries.GetConsultantUser
{
    public sealed record GetConsultantUserQuery(PagingRequest? PagingRequest, Guid? Id, string? Fullname, string? Email, string? Phone, Gender? Gender) : IRequest<PagedResult<GetConsultantUserResponse>>;

    public record GetConsultantUserResponse(
        Guid Id,
        string Fullname,
        string Email,
        string Phone,
        string Gender,
        DateTime? CreationDate);
}

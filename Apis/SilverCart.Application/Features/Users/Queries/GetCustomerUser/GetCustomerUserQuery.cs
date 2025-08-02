using Infrastructures.Commons.Paginations;
using MediatR;
using SilverCart.Domain.Commons.Enums;

namespace Infrastructures.Features.Users.Queries.GetCustomerUser
{
    public sealed record GetCustomerUserQuery(PagingRequest? PagingRequest, Guid? Id, string? Fullname, string? Email, string? Phone, Gender? Gender) : IRequest<PagedResult<GetCustomerUserResponse>>;

    public record GetCustomerUserResponse(
        Guid Id,
        string Fullname,
        string Email,
        string Phone,
        string Gender,
        DateTime? CreationDate);
}

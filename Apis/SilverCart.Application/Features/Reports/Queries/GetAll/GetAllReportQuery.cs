using Infrastructures.Commons.Paginations;
using MediatR;
using SilverCart.Domain.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Reports.Queries.GetAll
{
    public sealed record GetAllReportQuery(PagingRequest? PagingRequest, Guid? Id, string? Title) : IRequest<PagedResult<GetAllReportResponse>>;

    public record GetAllReportResponse(
        Guid Id,
        string Title,
        string Description,
        string FilePath,
        DateTime? CreationDate,
        Guid? CreatedById);
}

using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Reports.Queries.GetAll
{
    public class GetAllReportHandler : IRequestHandler<GetAllReportQuery, PagedResult<GetAllReportResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllReportHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<GetAllReportResponse>> Handle(GetAllReportQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.ReportRepository.GetAllAsync(
                predicate: x => !x.IsDeleted
                //,
                //include: source => source
                //    .Include(x => x.)
            );

            var filteredEntity = new SilverCart.Domain.Entities.Report
            {
                Id = request.Id.HasValue ? request.Id.Value : Guid.Empty,
                Title = !string.IsNullOrEmpty(request.Title) ? request.Title : string.Empty,
            };

            var filteredReports = query.AsQueryable().CustomFilterV1(filteredEntity);

            var mappedReports = await filteredReports
                .Select(report => new GetAllReportResponse(
                    report.Id,
                    report.Title,
                    report.Description,
                    report.FilePath,
                    report.CreationDate,
                    report.CreatedById
                )).ToListAsync(cancellationToken);

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
            var sortedResult = PaginationHelper<GetAllReportResponse>.Sorting(sortType, mappedReports, sortField);
            var result = PaginationHelper<GetAllReportResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}

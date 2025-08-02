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

namespace Infrastructures.Features.Users.Queries.GetConsultantUser
{
    public class GetConsultantUserHandler : IRequestHandler<GetConsultantUserQuery, PagedResult<GetConsultantUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConsultantUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<GetConsultantUserResponse>> Handle(GetConsultantUserQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.ConsultantUserRepository.GetAllAsync(
                predicate: x => !x.IsDeleted
                ,
                include: source => source
                    .Include(x => x.Consultations)
            );
            //Filtering
            if (request.Id.HasValue)
            {
                query = query.Where(x => x.Id == request.Id.Value);
            }
            if (!string.IsNullOrEmpty(request.Fullname))
            {
                query = query.Where(x => x.FullName.ToLower().Contains(request.Fullname.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(request.Email.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Phone))
            {
                query = query.Where(x => x.PhoneNumber.Contains(request.Phone));
            }
            if (request.Gender.HasValue)
            {
                query = query.Where(x => x.Gender == request.Gender.ToString());
            }
            //Mapping
            var mappedSystemAccounts = await query
                .Select(account => new GetConsultantUserResponse(
                    account.Id,
                    account.FullName,
                    account.Email,
                    account.PhoneNumber,
                    account.Gender,
                    account.CreationDate
                )).ToListAsync(cancellationToken);

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
            var sortedResult = PaginationHelper<GetConsultantUserResponse>.Sorting(sortType, mappedSystemAccounts, sortField);
            var result = PaginationHelper<GetConsultantUserResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}

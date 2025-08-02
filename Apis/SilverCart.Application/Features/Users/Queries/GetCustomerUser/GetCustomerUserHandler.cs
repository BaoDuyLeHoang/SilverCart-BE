using Infrastructures.Commons.Paginations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Infrastructures.Features.Users.Queries.GetCustomerUser;

namespace Infrastructures.Users.Queries.GetCustomerUser
{
    public class GetCustomerUserHandler : IRequestHandler<GetCustomerUserQuery, PagedResult<GetCustomerUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<GetCustomerUserResponse>> Handle(GetCustomerUserQuery request, CancellationToken cancellationToken)
        {
            var query = await _unitOfWork.CustomerUserRepository.GetAllAsync(
                predicate: x => !x.IsDeleted
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
                .Select(account => new GetCustomerUserResponse(
                    account.Id,
                    account.FullName,
                    account.Gender,
                    account.Email,
                    account.PhoneNumber,
                    account.CreationDate
                )).ToListAsync(cancellationToken);

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
            var sortedResult = PaginationHelper<GetCustomerUserResponse>.Sorting(sortType, mappedSystemAccounts, sortField);
            var result = PaginationHelper<GetCustomerUserResponse>.Paging(sortedResult, page, pageSize);

            return result;
        }
    }
}

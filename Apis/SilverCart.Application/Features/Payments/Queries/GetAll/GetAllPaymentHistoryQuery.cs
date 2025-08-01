using Core.Interfaces;
using Infrastructures.Commons.Paginations;
using Infrastructures.Services.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.PaymentHistories.Queries.GetAllPaymentHistories
{
    public sealed record GetAllPaymentHistoriesQuery(
        PagingRequest? PagingRequest,
        Guid? WalletId,
        Guid? PaymentMethodId,
        Guid? PromotionId,
        Guid? CustomerUserId
    ) : IRequest<PagedResult<GetAllPaymentHistoriesResponse>>;

    public record GetAllPaymentHistoriesResponse(
        Guid Id,
        double Amount,
        DateTime? CreatedDate,
        string PaymentMethodName,
        string? PromotionName,
        string CustomerName,
        string Note,
        string Points,
        string NewBalance,
        string PreviousBalance,
        PaymentStatusEnum Status
    );

    public class GetAllPaymentHistoriesQueryHandler(
        IUnitOfWork unitOfWork,
        IRedisService redisService
    ) : IRequestHandler<GetAllPaymentHistoriesQuery, PagedResult<GetAllPaymentHistoriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<PagedResult<GetAllPaymentHistoriesResponse>> Handle(GetAllPaymentHistoriesQuery request, CancellationToken cancellationToken)
        {
            var histories = await _unitOfWork.PaymentHistoryRepository.GetAllAsync(
                predicate: _ => true,
                include: x => x
                    .Include(x => x.CustomerUser)
                    .Include(x => x.PaymentMethod)
                    .Include(x => x.Promotion)
                    .Include(x => x.Wallet)
            );

            var filtered = histories.AsQueryable();

            if (request.WalletId.HasValue)
                filtered = filtered.Where(x => x.WalletId == request.WalletId.Value);
            if (request.PaymentMethodId.HasValue)
                filtered = filtered.Where(x => x.PaymentMethodId == request.PaymentMethodId.Value);
            if (request.PromotionId.HasValue)
                filtered = filtered.Where(x => x.PromotionId == request.PromotionId.Value);
            if (request.CustomerUserId.HasValue)
                filtered = filtered.Where(x => x.CustomerUserId == request.CustomerUserId.Value);

            var mapped = filtered.Select(x => new GetAllPaymentHistoriesResponse(
                x.Id,
                (double)x.Amount,
                x.CreationDate,
                x.PaymentMethod.Name,
                x.Promotion.Name ?? "No Promotion",
                x.CustomerUser.FullName,
                x.Note,
                x.Points.ToString(),
                x.NewBalance.ToString(),
                x.PreviousBalance.ToString(),
                x.Status.Value
            ));

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
            var sorted = PaginationHelper<GetAllPaymentHistoriesResponse>.Sorting(sortType, mapped, sortField);
            var paged = PaginationHelper<GetAllPaymentHistoriesResponse>.Paging(sorted, page, pageSize);

            return paged;
        }
    }
}

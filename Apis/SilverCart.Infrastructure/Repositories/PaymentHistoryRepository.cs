using Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Enums;

namespace Infrastructures.Repositories
{
    public class PaymentHistoryRepository : GenericRepository<PaymentHistory>, IPaymentHistoryRepository
    {
        public PaymentHistoryRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<PaymentHistory>> GetAllPaymentHistoryAsync(Guid? id, string? paymentMethod, PaymentStatusEnum? status, string? promotion)
        {
            var query = _context.PaymentHistories
                .Include(p => p.CustomerUser)
                .Include(p => p.Promotion)
                .Include(p => p.PaymentMethod)
                .AsQueryable();

            if (id.HasValue && id != Guid.Empty)
                query = query.Where(ph => ph.CustomerUserId == id.Value);

            if (!string.IsNullOrWhiteSpace(paymentMethod))
                query = query.Where(ph => ph.PaymentMethod.Name.Contains(paymentMethod));

            if (status.HasValue)
                query = query.Where(ph => ph.Status == status.Value);

            if (!string.IsNullOrWhiteSpace(promotion))
                query = query.Where(ph => ph.Promotion.Name.Contains(promotion));

            return await query.ToListAsync();
        }

    }
}
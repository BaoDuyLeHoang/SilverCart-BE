using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities.Payments;

namespace Infrastructures.Repositories
{
    public class PaymentHistoryRepository : GenericRepository<PaymentHistory>, IPaymentHistoryRepository
    {
        public PaymentHistoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
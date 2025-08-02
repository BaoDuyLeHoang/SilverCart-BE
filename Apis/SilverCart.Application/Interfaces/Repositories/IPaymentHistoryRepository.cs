using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Payments;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IPaymentHistoryRepository : IGenericRepository<PaymentHistory>
    {
    }
}
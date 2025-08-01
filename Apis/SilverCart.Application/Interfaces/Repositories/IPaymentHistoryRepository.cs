using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Enums;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IPaymentHistoryRepository : IGenericRepository<PaymentHistory>
    {
        public Task<List<PaymentHistory>> GetAllPaymentHistoryAsync(Guid? Id, string? PaymentMethod, PaymentStatusEnum? status, string? promotion);
    }
}
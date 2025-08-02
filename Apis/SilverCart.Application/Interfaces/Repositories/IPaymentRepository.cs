using SilverCart.Domain.Entities.Payments;

namespace SilverCart.Application.Repositories;

public interface IPaymentRepository : IGenericRepository<PaymentMethod>
{
}
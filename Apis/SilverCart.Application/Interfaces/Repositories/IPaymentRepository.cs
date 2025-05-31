using SilverCart.Domain.Entities;

namespace SilverCart.Application.Repositories;

public interface IPaymentRepository : IGenericRepository<PaymentMethod>
{
}
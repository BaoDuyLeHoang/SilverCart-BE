using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Enums;

namespace SilverCart.Application.Repositories;

public interface IPaymentRepository : IGenericRepository<PaymentMethod>
{

}
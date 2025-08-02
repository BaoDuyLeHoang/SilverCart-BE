using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Payments;

namespace Infrastructures.Repositories;

public class PaymentRepository : GenericRepository<PaymentMethod>, IPaymentRepository
{
    public PaymentRepository(AppDbContext context) : base(context)
    {
    }
}
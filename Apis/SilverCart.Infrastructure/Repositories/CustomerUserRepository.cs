using Infrastructures.Repositories;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public class CustomerUserRepository : GenericRepository<CustomerUser>, ICustomerUserRepository
{
    public CustomerUserRepository(AppDbContext context) : base(context)
    {
    }
}

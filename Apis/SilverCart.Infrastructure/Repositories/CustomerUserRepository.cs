using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class CustomerUserRepository : GenericRepository<CustomerUser>, ICustomerUserRepository
    {
        public CustomerUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}

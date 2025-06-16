using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.Repositories
{
    public interface ICustomerUserRepository : IGenericRepository<CustomerUser>
    {
    }
}

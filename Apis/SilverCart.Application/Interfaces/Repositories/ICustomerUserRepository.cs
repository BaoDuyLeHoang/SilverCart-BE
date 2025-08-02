using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures;

public interface ICustomerUserRepository : IGenericRepository<CustomerUser>
{
}

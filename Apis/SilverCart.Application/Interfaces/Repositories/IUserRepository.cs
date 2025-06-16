using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.Entities
{
    public interface IUserRepository : IGenericRepository<BaseUser>
    {
    }
}

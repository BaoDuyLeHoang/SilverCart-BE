using Infrastructures.Interfaces.Entities;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class UserRepository : GenericRepository<BaseUser>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

    }
}

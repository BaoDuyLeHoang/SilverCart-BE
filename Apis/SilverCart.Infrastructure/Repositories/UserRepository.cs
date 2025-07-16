using Infrastructures.Interfaces.Entities;
using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class UserRepository : GenericRepository<BaseUser>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }


    }
}
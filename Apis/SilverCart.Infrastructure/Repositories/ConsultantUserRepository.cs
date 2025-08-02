using Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class ConsultantUserRepository(AppDbContext context) : GenericRepository<ConsultantUser>(context), IConsultantUserRepository
    {
        public async Task<ConsultantUser?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<List<ConsultantUser>> GetBySpecializationAsync(string specialization)
        {
            return await _dbSet
                .Where(c => c.Specialization == specialization)
                .ToListAsync();
        }
    }
}

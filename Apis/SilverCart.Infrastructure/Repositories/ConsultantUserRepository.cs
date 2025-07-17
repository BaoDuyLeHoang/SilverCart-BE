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
    public class ConsultantUserRepository : GenericRepository<ConsultantUser>, IConsultantUserRepository
    {
        private readonly AppDbContext _context;
        public ConsultantUserRepository(AppDbContext context) : base(context) { }

        public async Task<ConsultantUser?> GetByEmailAsync(string email)
        {
            return await _context.ConsultantUsers
                .Include(c => c.Role)
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<List<ConsultantUser>> GetBySpecializationAsync(string specialization)
        {
            return await _context.ConsultantUsers
                .Where(c => c.Specialization == specialization)
                .ToListAsync();
        }
    }
}

using Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class ConsultationRepository : GenericRepository<Consultation>, IConsultationRepository
    {
        public ConsultationRepository(AppDbContext context) : base(context) { }


        public async Task<SilverCart.Domain.Entities.Consultation?> GetDetailsById(Guid consultationId)
        {
            return await _dbSet
                .Include(c => c.ConsultantUser)
                .Include(c => c.DependentUser)
                .FirstOrDefaultAsync(c => c.Id == consultationId);
        }

        public async Task<List<Consultation>> GetByConsultantAsync(Guid consultantId)
        {
            return await _dbSet
                .Where(c => c.ConsultantUser.Id == consultantId)
                .Include(c => c.ConsultantUser)
                .Include(c => c.DependentUser)
                .ToListAsync();
        }
    }
}

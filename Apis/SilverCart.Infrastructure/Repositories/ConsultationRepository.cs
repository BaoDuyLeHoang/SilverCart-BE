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
        private readonly AppDbContext _context;
        public ConsultationRepository(AppDbContext context) : base(context) { }


        public async Task<Consultation?> GetDetailsById(Guid consultationId)
        {
            return await _context.Consultations
                .Include(c => c.ConsultantUser)
                .FirstOrDefaultAsync(c => c.ConsultantId == consultationId);
        }

        public async Task<List<Consultation>> GetByConsultantAsync(Guid consultantId)
        {
            return await _context.Consultations
                .Where(c => c.ConsultantId == consultantId)
                .ToListAsync();
        }
    }
}

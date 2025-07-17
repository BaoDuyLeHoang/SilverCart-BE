using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IConsultationRepository : IGenericRepository<Consultation>
    {
        public Task<Consultation?> GetDetailsById(Guid consultationId);
        public Task<List<Consultation>> GetByConsultantAsync(Guid consultantId);
    }
}

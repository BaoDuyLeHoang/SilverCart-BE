using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities.Auth
{
    public class ConsultantUser : BaseUser
    {
        public Guid? ConsultantId { get; set; } // Unique identifier for the consultant
        public string Specialization { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public string AvatarPath { get; set; } = null!;
        public string ExpertiseArea { get; set; } = string.Empty;
        public string? StringeeAccessToken { get; set; }
        public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
        // Navigation property to the consultant entity
    }
}

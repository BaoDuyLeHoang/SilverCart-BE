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
        public Guid RoleId { get; set; }
        public ConsultantRole Role { get; set; } = null!;
        public string Specialization { get; set; } = null!;

        public string Biography { get; set; } = null!;
        public string AvatarPath { get; set; } = null!;
        public string ExpertiseArea { get; set; } = string.Empty;

        //public double YearsOfExperience { get; set; }
        //public string Certification { get; set; } = null!;
        //public bool Status { get; set; } = true; // true for active, false for inactive
        //public DateOnly UpdatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        //public ConsultantUser ConsultantUser { get; set; } = null!;
        //public ConsultantUser? Consultant { get; set; } // Navigation property to the consultant user
        public string? StringeeAccessToken { get; set; }
        public ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();
        // Navigation property to the consultant entity
    }
}

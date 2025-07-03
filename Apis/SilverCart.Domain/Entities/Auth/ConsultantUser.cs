using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities.Auth
{
    public class ConsultantUser : BaseUser
    {
        public ConsultantUser()
        {
        }



        public string Specialization { get; set; } = null!;

        public Guid RoleId { get; set; }
        public ConsultantRole Role { get; set; } = null!;

        public Guid? ConsultantId { get; set; } // Unique identifier for the consultant
        public ConsultantUser? Consultant { get; set; } // Navigation property to the consultant user
        public string? StringeeAccessToken { get; set; }
        public ICollection<Consultant> Consultants { get; set; } = new List<Consultant>(); // Collection of consultations associated with the consultant user
    }
}

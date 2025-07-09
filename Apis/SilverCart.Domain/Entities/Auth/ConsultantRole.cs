using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities.Auth
{
    public class ConsultantRole
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // ✅ Primary Key

        public string RoleName { get; set; } = string.Empty; // optional field
        public string? Description { get; set; }             // optional field

        public virtual ICollection<ConsultantUser> Consultants { get; set; } = new HashSet<ConsultantUser>();
    }
}

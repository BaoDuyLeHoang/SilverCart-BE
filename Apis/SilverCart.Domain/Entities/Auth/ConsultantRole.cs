using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities.Auth
{
    public class ConsultantRole
    {
        public virtual ICollection<ConsultantUser> Consultants { get; set; } = new HashSet<ConsultantUser>();
    }
}

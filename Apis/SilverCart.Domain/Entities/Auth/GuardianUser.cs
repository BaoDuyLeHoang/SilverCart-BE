using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilverCart.Domain.Entities.Carts;

namespace SilverCart.Domain.Entities.Auth
{
    public class GuardianUser : CustomerUser
    {
        public GuardianUser()
        {
            // Guardian-specific initialization
        }

        // Guardian-specific properties
        public ICollection<DependentUser> Dependents { get; set; } = new HashSet<DependentUser>();
    }
}
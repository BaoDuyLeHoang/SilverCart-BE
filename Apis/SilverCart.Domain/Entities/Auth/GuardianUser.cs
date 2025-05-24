using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities.Auth
{
    public class GuardianUser : BaseUser
    {
        public GuardianUser()
        {

        }
        public ICollection<DependentUser> Dependents { get; set; } = new HashSet<DependentUser>();
    }
}
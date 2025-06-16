using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities.Auth
{
    public class DependentUser : BaseUser
    {
        public DependentUser()
        {
        }
        public Guid GuardianId { get; set; }
        public GuardianUser Guardian { get; set; } = null!;
    }
}
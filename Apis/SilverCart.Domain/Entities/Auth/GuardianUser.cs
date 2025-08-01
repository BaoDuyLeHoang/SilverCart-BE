using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilverCart.Domain.Entities.Carts;

namespace SilverCart.Domain.Entities.Auth
{
    public class GuardianUser : BaseUser
    {
        public GuardianUser()
        {

        }
        public Wallet? Wallet { get; set; }
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<DependentUser> Dependents { get; set; } = new HashSet<DependentUser>();
        public ICollection<CustomerUser> Dependants { get; set; } = new HashSet<CustomerUser>();
    }
}
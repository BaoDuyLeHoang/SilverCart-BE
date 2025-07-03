using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities
{
    public class Consultant
    {
        public string Name { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public string AvatarPath { get; set; } = null!;
        public string ExpertiseArea { get; set; } = string.Empty;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public double YearsOfExperience { get; set; }
        public string Certification { get; set; } = null!;
        public bool Status { get; set; } = true; // true for active, false for inactive
        public DateOnly UpdatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
       

    }
}

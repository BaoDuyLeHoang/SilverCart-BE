using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities.Auth
{
    public class DependentUser : BaseUser
    {
        public DependentUser()
        {
        }
        public Guid GuardianId { get; set; }
        public virtual GuardianUser Guardian { get; set; } = null!;
        public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

        // New fields for CreateRelativeCommand
        public DateTime? DateOfBirth { get; set; }
        public RelationshipEnum Relationship { get; set; }
        public string? MedicalNotes { get; set; }
        public decimal? MonthlySpendingLimit { get; set; }
        public Guid? AddressId { get; set; }
        public List<int>? SuggestedCategoryIds { get; set; }
    }
}
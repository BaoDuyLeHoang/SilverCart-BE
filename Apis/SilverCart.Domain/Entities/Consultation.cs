using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverCart.Domain.Entities
{
    public class Consultation : BaseEntity // Assuming BaseEntity is a generic base class for entities with an ID of type Guid
    {

        public Guid ConsultationId { get; set; } = Guid.NewGuid(); // Unique identifier for the consultation

        //public ConsultantUser ConsultantUser { get; set; } = null!;

        //public DependentUser DependentUser { get; set; }          // Elderly customer (could be CustomerUser or DependentUser)
        public Guid ConsultantId { get; set; }
        public ConsultantUser ConsultantUser { get; set; } = null!;

        public Guid CustomerId { get; set; }
        public DependentUser DependentUser { get; set; } = null!;

        //public BaseUser ElderlyUser { get; set; } = null!; // You can use BaseUser if polymorphic

        public string ReportContent { get; set; } = string.Empty;  // Text report of the session

        public string? VideoRecordingUrl { get; set; }   // Link to the recorded video call (e.g., from cloud)

        //public DateTime ScheduledTime { get; set; }      // When the consultation was scheduled
        public DateTime? CompletedTime { get; set; }     // When it actually finished

        public bool IsCompleted { get; set; } = false;   // Status flag
        public string? Notes { get; set; }               // Optional extra notes

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}

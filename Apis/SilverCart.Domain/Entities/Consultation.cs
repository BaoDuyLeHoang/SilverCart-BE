using SilverCart.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilverCart.Domain.Entities.Products;

namespace SilverCart.Domain.Entities
{
    public class Consultation : BaseEntity // Assuming BaseEntity is a generic base class for entities with an ID of type Guid
    {

        [StringLength(int.MaxValue, MinimumLength = 100)]
        public string ReportContent { get; set; } = string.Empty;  // Text report of the session

        public string? VideoRecordingUrl { get; set; }   // Link to the recorded video call (e.g., from cloud)

        public DateTime? CompletedTime { get; set; }     // When it actually finished

        public bool IsCompleted { get; set; } = false;   // Status flag
        public string? Notes { get; set; }               // Optional extra notes
                                                         //Navigation Properties

        public Guid ConsultantId { get; set; }
        public virtual ConsultantUser ConsultantUser { get; set; } = null!;
        public Guid DependentUserId { get; set; }
        public virtual DependentUser DependentUser { get; set; } = null!;
        public List<Product> RecommendationProducts { get; set; } = new List<Product>();
    }
}

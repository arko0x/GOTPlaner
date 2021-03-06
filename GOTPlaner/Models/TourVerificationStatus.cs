using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class TourVerificationStatus
    {
        [Key]
        [Required]
        public TourVerificationStatusId TourVerificationStatusId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public IEnumerable<TourVerification> TourVerifications { get; set; }
    }
}

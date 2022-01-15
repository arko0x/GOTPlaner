using System;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class TourVerification
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public Tour Tour { get; set; }
        public Leader Leader { get; set; }
        [MaxLength(255)]
        public string Reason { get; set; }
        public DateTime VerificationDate { get; set; }
        [Required]
        public TourVerificationStatusId TourVerificationStatusId { get; set; }
        public TourVerificationStatus Status { get; set; }
    }
}

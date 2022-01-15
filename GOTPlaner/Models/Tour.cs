using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class Tour
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public Tourist Tourist { get; set; }
        [Required]
        public BadgeType BadgeType { get; set; }
        public IEnumerable<SegmentCross> SegmentCrosses { get; set; }
        public IEnumerable<TourVerification> TourVerifications { get; set; }
    }
}

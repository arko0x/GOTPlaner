using System;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class SegmentCross
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        [Required]
        public int SegmentId { get; set; }
        public Segment Segment { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public bool Direction { get; set; }
        public Nullable<DateTime> CrossDate { get; set; }
        [MaxLength(255)]
        public string ImageName { get; set; }
    }
}

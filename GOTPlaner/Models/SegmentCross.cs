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
        public Tour Tour { get; set; }
        [Required]
        public Segment Segment { get; set; }
        [Required]
        public int Order { get; set; }
        public DateTime CrossDate { get; set; }
        public string ImageName { get; set; }
    }
}

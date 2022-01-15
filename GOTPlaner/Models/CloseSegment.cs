using System;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class CloseSegment
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public Segment Segment { get; set; }
        [Required]
        public DateTime ClosedDate { get; set; }
        public Nullable<DateTime> OpenDate { get; set; }
        [MaxLength(255)]
        public string Reason { get; set; }
    }
}

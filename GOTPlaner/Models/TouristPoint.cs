using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class TouristPoint
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public MountainRangeId MountainRangeId { get; set; }
        public MountainRange MountainRange { get; set; }
        [Required]
        public ElementTypeId ElementTypeId { get; set; }
        public ElementType ElementType { get; set; }
        public IEnumerable<Segment> SegmentsA { get; set; }
        public IEnumerable<Segment> SegmentsB { get; set; }
    }
}

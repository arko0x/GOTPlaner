using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class Segment
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public TouristPoint TouristPointA { get; set; }
        [Required]
        public TouristPoint TouristPointB { get; set; }
        [Required]
        public int PointsAB { get; set; }
        public int PointsBA { get; set; }
        [Required]
        public int LevelDifferenceSum { get; set; }
        [Required]
        public int NumberOfKilometers { get; set; }
        [Required]
        public int SegmentTypeId { get; set; }
        public ElementTypeId SegmentType { get; set; }
        public IEnumerable<SegmentCross> SegmentCrosses { get; set; }
        public IEnumerable<CloseSegment> SegmentCloses { get; set; }
    }
}

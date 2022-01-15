using Microsoft.EntityFrameworkCore;
using System;
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
        public int TouristPointAId { get; set; }
        [Required]
        public TouristPoint TouristPointB { get; set; }
        [Required]
        public int TouristPointBId { get; set; }
        [Required]
        public int PointsAB { get; set; }
        public Nullable<int> PointsBA { get; set; }
        [Required]
        public int LevelDifferenceSum { get; set; }
        [Required]
        public int NumberOfKilometers { get; set; }
        [Required]
        public ElementTypeId ElementTypeId { get; set; }
        public ElementType ElementType { get; set; }
        public IEnumerable<SegmentCross> SegmentCrosses { get; set; }
        public IEnumerable<CloseSegment> SegmentCloses { get; set; }
    }
}

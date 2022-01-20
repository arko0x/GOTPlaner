using GOTPlaner.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.ViewModels
{
    public class CreateSegmentViewModel
    {
        public Segment Segment { get; set; }
        [Required]
        [MaxLength(255)]
        public string PointA { get; set; }
        [Required]
        [MaxLength(255)]
        public string PointB { get; set; }
        [Required]
        public int PointsAB { get; set; }
        public int PointsBA { get; set; }
        [Required]
        public int LevelDifferenceSum { get; set; }
        [Required]
        public int NumberOfKilometers { get; set; }
        public IEnumerable<MountainRange> MountainRanges { get; set; }
        [Required]
        public MountainRangeId MountainRangeAId { get; set; }
        [Required]
        public MountainRangeId MountainRangeBId { get; set; }
        public bool IsSegmentAlreadyInASystem { get; set; }
        public bool AreTouristPointsTheSame { get; set; }
    }
}

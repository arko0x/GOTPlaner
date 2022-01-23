using GOTPlaner.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.ViewModels
{
    public class CreateSegmentViewModel
    {
        public Segment Segment { get; set; }
        [Required(ErrorMessage = "Pole Punkt A jest wymagane")]
        [MaxLength(255)]
        public string PointA { get; set; }
        [Required(ErrorMessage = "Pole Punkt B jest wymagane")]
        [MaxLength(255)]
        public string PointB { get; set; }
        [Required(ErrorMessage = "Pole Punkty AB jest wymagane")]
        public int PointsAB { get; set; }
        public int PointsBA { get; set; }
        [Required(ErrorMessage = "Pole Suma różnic poziomów jest wymagane")]
        public int LevelDifferenceSum { get; set; }
        [Required(ErrorMessage = "Pole Liczba kilometrów jest wymagane")]
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

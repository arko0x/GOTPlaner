using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class MountainRange
    {
        [Key]
        public MountainRangeId MountainRangeId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class LeaderPermission
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public Leader Leader { get; set; }
        [Required]
        public MountainGroupId MountainGroupId { get; set; }
        public MountainGroup MountainGroup { get; set; }
    }
}

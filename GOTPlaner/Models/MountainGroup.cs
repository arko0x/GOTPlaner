using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class MountainGroup
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public IEnumerable<LeaderPermission> LeaderPermissions { get; set; }
    }
}

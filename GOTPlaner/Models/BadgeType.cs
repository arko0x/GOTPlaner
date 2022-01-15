using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class BadgeType
    {
        [Key]
        [Required]
        public BadgeTypeId BadgeTypeId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public IEnumerable<Badge> Badges { get; set; }
        public IEnumerable<Tour> Tours { get; set; }
    }
}

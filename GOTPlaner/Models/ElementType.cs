using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class ElementType
    {
        [Key]
        public ElementTypeId ElementTypeId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public IEnumerable<Segment> Segments { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class Badge
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public BadgeTypeId BadgeTypeId { get; set; }
        public BadgeType BadgeType { get; set; }
        [Required]
        public Tourist Tourist { get; set; }
        [Required]
        public DateTime ReceivalDate { get; set; }
    }
}

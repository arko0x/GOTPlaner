using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class Tourist
    {
        [Key]
        [MaxLength(255)]
        [Required]
        public string Email { get; set; }
        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(255)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [MaxLength(255)]
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Disability { get; set; }
        public IEnumerable<Badge> Badges { get; set; }
        public IEnumerable<Tour> Tours { get; set; }
    }
}

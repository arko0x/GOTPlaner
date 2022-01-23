using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class Leader
    {
        [Key]
        [MaxLength(255)]
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool Disability { get; set; }
        [Required]
        public int IDCard { get; set; }
        public IEnumerable<TourVerification> TourVerifications { get; set; }
        public IEnumerable<LeaderPermission> LeaderPermissions { get; set; }
    }
}

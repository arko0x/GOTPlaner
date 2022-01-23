using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [MaxLength(255)]
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        [CustomDateValidator]
        public DateTime BirthDate { get; set; }
        [NotMapped]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        public bool Disability { get; set; }
        public IEnumerable<Badge> Badges { get; set; }
        public IEnumerable<Tour> Tours { get; set; }
    }
}

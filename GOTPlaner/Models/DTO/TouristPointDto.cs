using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models.DTO
{
    public class TouristPointDto
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string APIName { get; set; }
        [Required]
        public MountainRangeId MountainRangeId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TouristPointDto)
            {
                return this.ID == (obj as TouristPointDto).ID;
            }
            return false;
        }
    }
}

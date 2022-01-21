using GOTPlaner.Models.DTO;

namespace GOTPlaner.Models
{
    public class ToursPointInfo
    {
        public TouristPointDto TouristPointDto { get; set; }
        public int PointsToGain { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ToursPointInfo)
            {
                return TouristPointDto.ID == (obj as ToursPointInfo).TouristPointDto.ID;
            }
            else return false;
        }
    }
}

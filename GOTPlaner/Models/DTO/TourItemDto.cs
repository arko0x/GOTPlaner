using Newtonsoft.Json;

namespace GOTPlaner.Models.DTO
{
    public class TourItemDto
    {
        [JsonProperty("touristPointId")]
        public int TouristPointId { get; set; }

        [JsonProperty("touristPointName")]
        public string TouristPointName { get; set; }

        [JsonProperty("ownPoint")]
        public bool OwnPoint { get; set; }

        [JsonProperty("currentPoints")]
        public int? CurrentPoints { get; set; }
        [JsonProperty("numberOfKilometers")]
        public int? NumberOfKilometers { get; set; }
        [JsonProperty("levelDifference")]
        public int? LevelDifference { get; set; }
        [JsonProperty("mountainRangeId")]
        public int MountainRangeId { get; set; }
    }
}

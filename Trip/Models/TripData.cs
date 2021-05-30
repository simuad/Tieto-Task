using Newtonsoft.Json;

namespace Trip.Models
{
    public class TripData
    {

        [JsonProperty("distance")]
        public int Distance { get; set; }

        [JsonProperty("distancePerDay")]
        public int DistancePerDay { get; set; } = 20;

        [JsonProperty("numberOfPeople")]
        public int NumberOfPeople { get; set; } = 1;

        [JsonProperty("mealsPerDay")]
        public int MealsPerDay { get; set; } = 1;

        [JsonProperty("season")]
        public string Season { get; set; }
    }
}

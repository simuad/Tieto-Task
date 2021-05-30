using Newtonsoft.Json;
using System.Collections.Generic;

namespace Trip.Models
{
    public class TripCheckList
    {
        [JsonProperty("tripDurationInDays")]
        public int TripDurationInDays { get; set; }

        [JsonProperty("accommodationRequired")]
        public bool AccomodationRequired { get; set; }

        [JsonProperty("tripItems")]
        public List<Item> TripItems { get; set; } = new List<Item>();
    }
}

using Newtonsoft.Json;

namespace Trip.Models
{
    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        public Item(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }
    }
}

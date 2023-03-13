using Newtonsoft.Json;

namespace Allari.Assessment.Web.Models
{
    public class StarWarsPeople
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("mass")]
        public int Mass { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }
    }
}

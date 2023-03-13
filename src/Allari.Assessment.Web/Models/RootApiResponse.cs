using Newtonsoft.Json;

namespace Allari.Assessment.Web.Models
{
    public class RootApiResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string? Next { get; set; }

        [JsonProperty("previous")]
        public object? Previous { get; set; }

        [JsonProperty("results")]
        public List<StarWarsPeople>? Results { get; set; }
    }
}

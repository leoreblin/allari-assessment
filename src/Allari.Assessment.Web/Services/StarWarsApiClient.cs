using Allari.Assessment.Web.Models;
using Allari.Assessment.Web.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Allari.Assessment.Web.Services
{
    public class StarWarsApiClient : IStarWarsApiClient
    {
        private readonly HttpClient _httpClient;
        private const string _endpoint = "https://swapi.dev/api/";

        public StarWarsApiClient()
        {
            _httpClient = new HttpClient();
        }

        ///<inheritdoc/>
        public List<StarWarsPeople> GetPeople(string path)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(string.Concat(_endpoint, path))
                };

                using var response = _httpClient.Send(request);
                response.EnsureSuccessStatusCode();
                StreamReader sr = new StreamReader(response.Content.ReadAsStream());
                JObject? data = (JObject)JsonConvert.DeserializeObject(sr.ReadToEnd());
                JArray? array = JArray.Parse(data["results"].ToString());
                return array.ToObject<List<StarWarsPeople>>();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }            
        }

        ///<inheritdoc/>
        public async Task<List<StarWarsPeople>> GetPeopleAsync(string path)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(string.Concat(_endpoint, path))
                };

                using var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var results = JsonConvert.DeserializeObject<RootApiResponse>(
                    await response.Content.ReadAsStringAsync());

                return results.Results ?? new List<StarWarsPeople>();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }            
        }
    }
}

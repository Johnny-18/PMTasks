using System.Text.Json.Serialization;

namespace Test.PrimeNumbers
{
    public class Settings
    {
        [JsonPropertyName("baseUrl")]
        public string BaseUrl { get; set; }
        
        [JsonPropertyName("api")]
        public string Api { get; set; }
    }
}
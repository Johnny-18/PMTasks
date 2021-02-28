using System.Text.Json.Serialization;

namespace WebApiTests
{
    public class Settings
    {
        [JsonPropertyName("baseUrl")]
        public string BaseUrl { get; set; }
        
        [JsonPropertyName("api")]
        public string Api { get; set; }
    }
}
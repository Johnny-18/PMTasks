using Newtonsoft.Json;

namespace Library.Models
{
    public class Cache
    {
        [JsonProperty("r030")]
        public int R030 { get; set; }
        
        [JsonProperty("txt")]
        public string Txt { get; set; }
        
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
        
        [JsonProperty("cc")]
        public string Сc { get; set; }
        
        [JsonProperty("exchangedate")]
        public string Exchangedate { get; set; }
    }
}
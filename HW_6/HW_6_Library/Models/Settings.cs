using System.Text.Json.Serialization;

namespace HW_6_Library.Models
{
    public class Settings
    {
        [JsonPropertyName("primesFrom")]
        public int PrimesFrom { get; set; }
        
        [JsonPropertyName("primesTo")]
        public int PrimesTo { get; set; }
    }
}
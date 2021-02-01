using System.Text.Json.Serialization;

namespace HW_6_Library.Models.SettingsTask
{
    public class Setting
    {
        [JsonPropertyName("primesFrom")]
        public int PrimesFrom { get; set; }
        
        [JsonPropertyName("primesTo")]
        public int PrimesTo { get; set; }
    }
}
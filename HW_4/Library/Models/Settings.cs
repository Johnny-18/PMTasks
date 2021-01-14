using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Settings
    {
        [JsonPropertyName("primesFrom")]
        public int PrimesFrom { get; }
        [JsonPropertyName("primesTo")]
        public int PrimesTo { get; }
        
        public Settings(int primesFrom, int primesTo)
        {
            PrimesFrom = primesFrom;
            PrimesTo = primesTo;
        }
    }
}
using System.Text.Json.Serialization;

namespace HW_6_Library.Models.LoginTask
{
    public class Result
    {
        [JsonPropertyName("successful")]
        public int Successful { get; set; }
        
        [JsonPropertyName("failed")]
        public int Failed { get; set; }
    }
}
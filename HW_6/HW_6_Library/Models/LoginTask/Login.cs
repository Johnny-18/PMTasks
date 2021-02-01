using System.Text.Json.Serialization;

namespace HW_6_Library.Models.LoginTask
{
    public class Login
    {
        [JsonPropertyName("login")]
        public string LoginValue { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
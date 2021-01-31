using System;
using System.Text.Json.Serialization;

namespace HW_6_Library.Models
{
    public class Result
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        
        [JsonPropertyName("error")]
        public string Error { get; set; }
        
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        
        [JsonPropertyName("primes")]
        public int[] Primes { get; set; }
    }
}
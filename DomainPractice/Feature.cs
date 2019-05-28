using Newtonsoft.Json;

namespace DomainPractice
{
    public class Feature
    {
        [JsonProperty("properties")]
        public Information Information { get; set; }
        public string Id { get; set; }
    }
}
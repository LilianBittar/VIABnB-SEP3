using Newtonsoft.Json;

namespace SEP3T2GraphQL.Models
{
    public class Administrator : User
    {
        [JsonProperty("initials")]
        public string Initials { get; set; }
    }
}
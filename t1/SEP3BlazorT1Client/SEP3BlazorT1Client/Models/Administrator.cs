using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class Administrator : User
    {
        [JsonProperty("initials")]
        public string Initials { get; set; }
    }
}
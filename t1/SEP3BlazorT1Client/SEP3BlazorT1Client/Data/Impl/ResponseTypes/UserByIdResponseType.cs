using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class UserByIdResponseType
    {
        [JsonProperty("userById")] public User User { get; set; }
    }
}
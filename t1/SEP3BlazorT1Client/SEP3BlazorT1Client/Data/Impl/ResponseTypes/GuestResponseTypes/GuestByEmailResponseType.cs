using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestResponseTypes
{
    public class GuestByEmailResponseType
    {
        [JsonProperty("guestByEmail")] public Guest Guest { get; set; }
    }
}
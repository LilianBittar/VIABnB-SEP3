using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestResponseTypes
{
    public class GuestByIdResponseType
    {
        [JsonProperty("guestById")] public Guest Guest { get; set; }
    }
}
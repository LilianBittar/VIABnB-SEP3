using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class RejectedRentRequestResponseType
    {
        [JsonProperty("rejectRentRequest")] public RentRequest RentRequest { get; set; }
    }
}
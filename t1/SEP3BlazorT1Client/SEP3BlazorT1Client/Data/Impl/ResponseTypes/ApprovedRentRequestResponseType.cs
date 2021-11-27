using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class ApprovedRentRequestResponseType
    {
        [JsonProperty("approveRentRequest")] public RentRequest RentRequest { get; set; }
    }
}
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.RentRequestResponseTypes
{
    public class UpdatedRentRequestResponseType
    {
        [JsonProperty("updateRentRequestStatus")]
        public RentRequest RentRequest { get; set; }
    }
}
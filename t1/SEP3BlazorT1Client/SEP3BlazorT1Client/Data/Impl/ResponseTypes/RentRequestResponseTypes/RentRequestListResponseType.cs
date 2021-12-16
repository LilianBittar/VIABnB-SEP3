using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.RentRequestResponseTypes
{
    public class RentRequestListResponseType
    {
        [JsonProperty("allRentRequestsByHostId")]
        public IEnumerable<RentRequest> RentRequests { get; set; } = new List<RentRequest>();
    }
}
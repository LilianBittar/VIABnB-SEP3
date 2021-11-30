using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class AllNotAnsweredRentRequestResponseType
    {
        [JsonProperty("allNotAnsweredRentRequest")]
        public IEnumerable<RentRequest> RentRequests { get; set; }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class RentRequestsByGuestIdQueryResponseType
    {
        
        [JsonProperty("rentRequestsByGuestId")]
        public IEnumerable<RentRequest> Requests { get; set; }
    }
}
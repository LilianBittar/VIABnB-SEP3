using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.HostReviewsResponseTypes
{
    public class AllHostReviewsByHostIdResponseType
    {
        [JsonProperty("allHostReviewsByHostId")]
        
        public IEnumerable<HostReview> HostReviews { get; set; }
    }
}
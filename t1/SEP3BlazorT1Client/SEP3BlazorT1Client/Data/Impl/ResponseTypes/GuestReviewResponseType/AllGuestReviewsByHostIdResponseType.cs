using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestReviewResponseType
{
    public class AllGuestReviewsByHostIdResponseType
    {
        [JsonProperty("allGuestReviewsByHostId")]
        
        public IEnumerable<GuestReview> GuestReviews { get; set; }
    }
}
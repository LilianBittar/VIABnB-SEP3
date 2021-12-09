using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestResponseTypes
{
    public class AllGuestReviewsByGuestIdResponseType
    {
        [JsonProperty("allGuestReviewsByGuestId")]
        public IEnumerable<GuestReview> GuestReviews { get; set; }
    }
}
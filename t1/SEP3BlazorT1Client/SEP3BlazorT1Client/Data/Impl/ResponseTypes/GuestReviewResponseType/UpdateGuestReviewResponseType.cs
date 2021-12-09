using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestReviewResponseType
{
    public class UpdateGuestReviewResponseType
    {
        
        [JsonProperty("updateGuestReview")]
        
        public GuestReview GuestReview { get; set; }
    }
}
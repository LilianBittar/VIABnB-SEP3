using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestReviewResponseType
{
    public class CreateGuestReviewResponseType
    {
        [JsonProperty("createGuestReview")]
        public GuestReview GuestReview { get; set; }
    }
}
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.HostReviewsResponseTypes
{
    public class CreateHostReviewResponseType
    {
        [JsonProperty("createHostReview")]
        public HostReview HostReview { get; set; }
    }
}
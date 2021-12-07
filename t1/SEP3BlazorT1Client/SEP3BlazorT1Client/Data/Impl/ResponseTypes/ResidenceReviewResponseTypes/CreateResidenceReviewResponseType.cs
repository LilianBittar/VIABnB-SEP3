using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.ResidenceReviewResponseTypes
{
    public class CreateResidenceReviewResponseType
    {
        [JsonProperty("createResidenceReview")]
        public ResidenceReview ResidenceReview { get; set; }
    }
}
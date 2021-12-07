using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.ResidenceReviewResponseTypes
{
    public class ResidenceReviewsByResidenceIdResponseType
    {
        [JsonProperty("allResidenceReviewsByResidenceId")]
        public IEnumerable<ResidenceReview> ResidenceReviews { get; set; }
    }
}
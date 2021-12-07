using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.FacilityResponseTypes
{
    public class DeleteResidenceFacilityResponseType
    {
        [JsonProperty("deleteResidenceFacility")]
        public Facility Facility { get; set; }
    }
}
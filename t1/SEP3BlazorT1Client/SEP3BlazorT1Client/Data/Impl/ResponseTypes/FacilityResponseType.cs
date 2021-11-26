using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class FacilityResponseType
    {
        [JsonProperty("getFacilityById")] public Facility Facility { get; set; }
    }
}
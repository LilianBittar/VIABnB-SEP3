using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.FacilityResponseTypes
{
    public class CreateFacilityResponseType
    {
        [JsonProperty("createNewFacility")] public Facility NewFacility { get; set; }
    }
}
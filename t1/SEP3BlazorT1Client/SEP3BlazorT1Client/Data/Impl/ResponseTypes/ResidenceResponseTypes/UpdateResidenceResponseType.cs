using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.ResidenceResponseTypes
{
    public class UpdateResidenceResponseType
    {
        [JsonProperty("updateResidence")] public Residence Residence { get; set; }
    }
}
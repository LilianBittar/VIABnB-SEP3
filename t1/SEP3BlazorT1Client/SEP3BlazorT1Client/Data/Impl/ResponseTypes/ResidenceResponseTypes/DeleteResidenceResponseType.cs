using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.ResidenceResponseTypes
{
    public class DeleteResidenceResponseType
    {
        [JsonProperty("deleteResidence")] public Residence Residence { get; set; }
    }
}
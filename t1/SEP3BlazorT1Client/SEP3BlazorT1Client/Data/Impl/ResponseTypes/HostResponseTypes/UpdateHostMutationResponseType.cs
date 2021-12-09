using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.HostResponseTypes
{
    public class UpdateHostMutationResponseType
    {
        [JsonProperty("updateHostStatus")]
        public Host updateHostStatus { get; set; }
    }
}
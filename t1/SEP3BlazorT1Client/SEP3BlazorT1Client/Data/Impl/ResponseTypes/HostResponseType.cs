using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class HostResponseType
    {
        /// <summary>
        /// GraphQL response container containing the queried residence. 
        /// </summary>
        /// <value></value>
        [JsonProperty("validateHostLogin")]
        public Host Host { get; set; }
    }
}
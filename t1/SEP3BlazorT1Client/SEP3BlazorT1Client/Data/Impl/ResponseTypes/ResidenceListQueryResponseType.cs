using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class ResidenceListQueryResponseType
    {
        /// <summary>
        /// GraphQL response container containing the queried residence by host id. 
        /// </summary>
        /// <value></value>
        [JsonProperty("residencesByHostId")]
        public IList<Residence> Residences { get; set; }
    }
}
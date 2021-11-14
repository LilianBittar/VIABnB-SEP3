using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class ResidenceListQueryResponseType
    {
        [JsonProperty("Residence")]
        public List<Residence> Residences { get; set; }
    }
}
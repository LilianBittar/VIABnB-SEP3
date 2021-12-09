using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.ResidenceResponseTypes
{
    public class ResidenceListQueryResponseType
    {
       
        [JsonProperty("residencesByHostId")]
        public IList<Residence> Residences { get; set; }
    }
}
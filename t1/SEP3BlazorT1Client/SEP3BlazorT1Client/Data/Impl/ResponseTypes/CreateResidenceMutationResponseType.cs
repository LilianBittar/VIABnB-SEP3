using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class CreateResidenceMutationResponseType
    {
        [JsonProperty("createResidence")]
        public Residence CreateResidence { get; set; }
        
        public override string ToString(){
            return JsonConvert.SerializeObject(this); 
        }
        
    }
}
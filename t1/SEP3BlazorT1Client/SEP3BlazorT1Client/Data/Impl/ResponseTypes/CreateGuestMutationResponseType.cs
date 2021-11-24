using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class CreateGuestMutationResponseType
    {
        [JsonProperty("createGuest")]
        public Guest CreateGuest { get; set; }
    }
}
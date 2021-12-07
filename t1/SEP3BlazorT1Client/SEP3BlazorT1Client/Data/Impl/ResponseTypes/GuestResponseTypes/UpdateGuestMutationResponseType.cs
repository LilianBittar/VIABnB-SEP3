using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.GuestResponseTypes
{
    public class UpdateGuestMutationResponseType
    {
        [JsonProperty("updateGuestStatus")]
        public Guest UpdateGuest { get; set; }
    }
}
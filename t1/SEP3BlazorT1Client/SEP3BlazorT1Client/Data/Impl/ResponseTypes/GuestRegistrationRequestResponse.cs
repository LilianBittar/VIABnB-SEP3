using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    class GuestRegistrationRequestResponse
    {
        [JsonProperty("createGuestRegistrationRequest")]
        public GuestRegistrationRequest CreateGuestRegistrationRequest { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class GuestListResponse
    {
        [JsonProperty("allNotApprovedGuest")] public IList<Guest> Guests { get; set; } = new List<Guest>();
    }
}
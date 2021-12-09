using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.AdminResponseTypes
{
    public class AdminListResponseType
    {
        [JsonProperty("allAdmins")] public IEnumerable<Administrator> Administrators { get; set; }
    }
}
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class AdminResponseType
    {
        [JsonProperty("getAdminByEmail")] public Administrator Administrator { get; set; }
    }
}
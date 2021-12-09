using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.AdminResponseTypes
{
    public class ValidateAdminResponseType
    {
        [JsonProperty("validateAdmin")] public Administrator Administrator { get; set; }
    }
}
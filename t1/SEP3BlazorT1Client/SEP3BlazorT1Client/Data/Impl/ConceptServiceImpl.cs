using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class ConceptServiceImpl : IConceptService
    {
        public async Task<ConceptMessage> getMessage(int id)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:5001/Concept/{id}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new($"@Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string conceptMessageAsJson = await responseMessage.Content.ReadAsStringAsync();

            ConceptMessage conceptMessage = JsonSerializer.Deserialize<ConceptMessage>(conceptMessageAsJson, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return conceptMessage;
        }
    }
}
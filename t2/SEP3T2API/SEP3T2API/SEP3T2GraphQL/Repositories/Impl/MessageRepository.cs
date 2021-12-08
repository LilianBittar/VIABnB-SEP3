using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class MessageRepository : IMessageRepository
    {
        private readonly HttpClient _client = new HttpClient();
        private const string Uri = "http://localhost:8080/messages";

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            var response = await _client.GetAsync(Uri);
            await HandleErrorMessage(response);
            return JsonSerializer.Deserialize<IEnumerable<Message>>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }

        public async Task<Message> CreateMessageAsync(Message message)
        {
            var messageAsJson = JsonSerializer.Serialize(message,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            var payload = new StringContent(messageAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(Uri, payload);
            await HandleErrorMessage(response);
            return JsonSerializer.Deserialize<Message>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }

        private static async Task HandleErrorMessage(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
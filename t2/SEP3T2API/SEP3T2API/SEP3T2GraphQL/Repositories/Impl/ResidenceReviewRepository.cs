using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public partial class ResidenceReviewRepository : IResidenceReviewRepository
    {
        private const string Uri = "http://localhost:8080";
        private readonly HttpClient _client = new HttpClient();

        public async Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview)
        {
            var residenceReviewAsJson = JsonSerializer.Serialize(residenceReview,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            StringContent payload = new(residenceReviewAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{Uri}/residences/{residence.Id}/residencereviews", payload);
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<ResidenceReview>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ResidenceReview> UpdateAsync(int residenceId, ResidenceReview updatedReview)
        {
            var residenceReviewAsJson = JsonSerializer.Serialize(updatedReview,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            StringContent payload = new(residenceReviewAsJson, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{Uri}/residences/{residenceId}/residencereviews", payload);
            await HandleErrorResponse(response);
            return JsonSerializer.Deserialize<ResidenceReview>(await response.Content.ReadAsStringAsync());
        }

        private static async Task HandleErrorResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
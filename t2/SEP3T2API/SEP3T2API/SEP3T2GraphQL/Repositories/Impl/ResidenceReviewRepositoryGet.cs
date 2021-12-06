using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public partial class ResidenceReviewRepository : IResidenceReviewRepository
    {
        
        
        public Task<IEnumerable<ResidenceReview>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ResidenceReview>> GetAllByResidenceIdAsync(int residenceId)
        {
            HttpResponseMessage responseMessage = await _client.GetAsync($"{Uri}/residences/{residenceId}/residencereviews");
            Console.WriteLine(await responseMessage.Content.ReadAsStringAsync());
            
            await HandleErrorResponse(responseMessage);

            string result = await responseMessage.Content.ReadAsStringAsync();

            List<ResidenceReview> residenceReviews = JsonSerializer.Deserialize<List<ResidenceReview>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            return residenceReviews;
        }
        
       
    }
}
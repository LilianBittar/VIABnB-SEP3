using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public partial class ResidenceReviewRepository : IResidenceReviewRepository
    {
        public async Task<IEnumerable<ResidenceReview>> GetAllResidenceReviewByResidenceIdAsync(int residenceId)
        {
            var responseMessage = await _client.GetAsync($"{Uri}/residences/{residenceId}/residencereviews");
            await HandleErrorResponse(responseMessage);
            var result = await responseMessage.Content.ReadAsStringAsync();
            var residenceReviews = JsonSerializer.Deserialize<List<ResidenceReview>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return residenceReviews;
        }
        
       
    }
}
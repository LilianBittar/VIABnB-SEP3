using System;
using System.Net.Http;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public partial class ResidenceReviewRepository : IResidenceReviewRepository
    {
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;
        
        public Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResidenceReview> UpdateAsync(int residenceId, ResidenceReview updatedReview)
        {
            throw new System.NotImplementedException();
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
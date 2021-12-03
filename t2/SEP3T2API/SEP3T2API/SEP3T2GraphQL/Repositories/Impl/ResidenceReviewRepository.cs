using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public partial class ResidenceReviewRepository : IResidenceReviewRepository
    {
        
        public Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResidenceReview> UpdateAsync(int reviewId, ResidenceReview updatedReview)
        {
            throw new System.NotImplementedException();
        }
    }
}
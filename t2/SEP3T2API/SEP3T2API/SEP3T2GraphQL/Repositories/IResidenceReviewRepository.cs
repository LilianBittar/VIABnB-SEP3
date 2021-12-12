using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IResidenceReviewRepository
    {
        public Task<ResidenceReview> CreateResidenceReviewAsync(Residence residence, ResidenceReview residenceReview);
        public Task<IEnumerable<ResidenceReview>> GetAllResidenceReviewByResidenceIdAsync(int residenceId);
        public Task<ResidenceReview> UpdateResidenceReviewAsync(int residenceId, ResidenceReview updatedReview); 

    }
}
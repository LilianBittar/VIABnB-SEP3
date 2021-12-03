using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IResidenceReviewService
    {
        public Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview);
        public Task<IEnumerable<ResidenceReview>> GetAllAsync(); 
        public Task<IEnumerable<ResidenceReview>> GetAllByResidenceIdAsync(int residenceId); 
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IResidenceReviewRepository
    {
        public Task<ResidenceReview> CreateResidenceReview(Residence residence, ResidenceReview residenceReview);
        public Task<IEnumerable<ResidenceReview>> GetAll(); 
        public Task<IEnumerable<ResidenceReview>> GetAllByResidenceId(); 
        
    }
}
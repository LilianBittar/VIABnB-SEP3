using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public partial class ResidenceReviewRepository : IResidenceReviewRepository
    {
        public Task<IEnumerable<ResidenceReview>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ResidenceReview>> GetAllByResidenceId()
        {
            throw new System.NotImplementedException();
        }
    }
}
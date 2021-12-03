using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Impl
{
    public partial class ResidenceReviewService : IResidenceReviewService
    {
        public Task<IEnumerable<ResidenceReview>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ResidenceReview>> GetAllByResidenceIdAsync(int residenceId)
        {
            throw new System.NotImplementedException();
        }
    }
}
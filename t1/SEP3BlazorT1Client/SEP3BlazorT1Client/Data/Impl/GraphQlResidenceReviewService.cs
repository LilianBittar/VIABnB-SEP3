using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlResidenceReviewService : IResidenceReviewService
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
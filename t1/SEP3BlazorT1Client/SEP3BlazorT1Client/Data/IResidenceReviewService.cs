using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IResidenceReviewService
    {
        public Task<IEnumerable<ResidenceReview>> GetAllAsync();
        public Task<IEnumerable<ResidenceReview>> GetAllByResidenceIdAsync(int residenceId);
        public Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview); 

    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IHostReviewService
    {
        
        Task<HostReview> CreateHostReviewAsync(HostReview hostReview);
        
        Task<HostReview> UpdateHostReviewAsync(HostReview hostReview);
        
        Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id);
    }
    
}
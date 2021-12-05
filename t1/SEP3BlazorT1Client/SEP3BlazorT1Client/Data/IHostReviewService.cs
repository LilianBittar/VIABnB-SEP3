using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IHostReviewService
    {
        
        Task<HostReview> CreateGuestReviewAsync(HostReview hostReview);
        
        Task<HostReview> UpdateGuestReviewAsync(HostReview hostReview);
        
        Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id);
    }
    
}
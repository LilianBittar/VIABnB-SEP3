using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IHostReviewService
    {
        /// <summary>
        /// Create a new HostReview object if any is not found, if any is found update the HostReview via repository
        /// </summary>
        /// <param name="hostReview">The new HostReview</param>
        /// <returns>The newly created H ostReview object</returns>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<HostReview> CreateHostReviewAsync(HostReview hostReview);
        /// <summary>
        /// Get a list of HostReview objects based on the given parameter via repository
        /// </summary>
        /// <param name="id">The targeted HostReview's Host's id</param>
        /// <exception cref="System.ArgumentException">If the repository can't execute the method</exception>
        Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id);
    }
    
}
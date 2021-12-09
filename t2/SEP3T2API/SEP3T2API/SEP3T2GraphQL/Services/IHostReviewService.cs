using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IHostReviewService
    {
        /// <summary>
        /// Creates a new <c>hostReview</c> for a guest
        /// </summary>
        /// <remarks>
        /// To create a new <c>GuestReview</c> the guest, that the host is reviewing, must have an RentRequest with status of <c>APPROVED</c>
        /// for the guest that the review is intended for. If the host have already made an review for that particular  guest,
        /// then the old review will get updated with the new <c>Rating</c>, <c>ReviewText</c> and <c>CreatedDate</c>. 
        /// </remarks>
        /// <param name="hostReview"></param>
        /// <returns>newly created review if no existing review exists, else the old review updated with the new values for properties</returns>
        Task<HostReview> CreateHostReviewAsync(HostReview hostReview);
        
        /// <summary>
        /// Updates <c>hostReview</c>
        /// </summary>
        /// <remarks>
        /// To update the <c>HostReview</c> there has to be a review with the same hostId and viaId that is already existing in the system,
        /// then the old review will get updated with the new <c>Rating</c>, <c>ReviewText</c> and <c>CreatedDate</c>. 
        /// </remarks>
        /// <param name="hostReview"></param>
        /// <returns>Newly updated review if there has been an existing review with the same hostId and viaId</returns>
        Task<HostReview> UpdateHostReviewAsync(HostReview hostReview);
        
        /// <summary>
        /// Returns an <c>IEnumerable</c> with all <c>HostReview</c> of a host with the id of <c>id</c>
        /// </summary>
        /// <param name="id">id of the host</param>
        /// <returns>All reviews of guests made by that host with id of <c>id</c></returns>
        Task<IEnumerable<HostReview>> GetAllHostReviewsByGuestIdAsync(int id);
        Task<IEnumerable<HostReview>> GetAllHostReviewsByHostIdAsync(int id);
    
    }
}
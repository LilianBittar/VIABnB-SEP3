using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IResidenceReviewService
    {
        /// <summary>
        /// Creates a new <c>ResidenceReview</c> for an residence
        /// </summary>
        /// <remarks>
        /// To create a new <c>ResidenceReview</c> the guest must have an RentRequest with status of <c>APPROVED</c>
        /// for the residence that the review is intended for. If the guest have already made an review for the residence,
        /// then the old review will get updated with the new <c>Rating</c>, <c>ReviewText</c> and <c>CreatedDate</c>. 
        /// </remarks>
        /// <param name="residence"></param>
        /// <param name="residenceReview"></param>
        /// <returns>newly created review if no existing review exists, else the old review updated with the new values for properties</returns>
        public Task<ResidenceReview> CreateAsync(Residence residence, ResidenceReview residenceReview);
        /// <summary>
        /// Returns an <c>IEnumerable</c> with all <c>ResidenceReview</c> created in the system. 
        /// </summary>
        /// <returns>all residence reviews</returns>
        public Task<IEnumerable<ResidenceReview>> GetAllAsync(); 
        /// <summary>
        /// Returns an <c>IEnumerable</c> with all <c>ResidenceReview</c> of a residence with the id of <c>residenceId</c>
        /// </summary>
        /// <param name="residenceId">id of the residence</param>
        /// <returns>all residence reviews of residence with id of <c>residenceId</c></returns>
        public Task<IEnumerable<ResidenceReview>> GetAllByResidenceIdAsync(int residenceId); 
    }
}
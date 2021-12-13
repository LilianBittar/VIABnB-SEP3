using System;
using System.Linq;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Services.Validation
{
    public class CreateGuestReviewValidation
    {
        private readonly IRentalService _rentalService;

        public CreateGuestReviewValidation(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        
        /// <summary>
        /// Validates if the guest under review has ever rented a residence owned by the host doing the review and rating is valid
        /// </summary>
        /// <remarks>Method will return void if valid, else an exception will be thrown</remarks>
        /// <param name="guestReview">review being validated</param>
        /// <exception cref="ArgumentException">If guest has no approved <c>RentRequest</c> for a residence owned by host of the <c>GuestReview</c></exception>
        /// <exception cref="ArgumentException">If rating is not between 0 and 5</exception>
        public async void ValidateGuestReview(GuestReview guestReview)
        {
            ValidateRating(guestReview);
            await ValidateGuestHasRentResidenceOfHost(guestReview);
        }

        private static void ValidateRating(GuestReview guestReview)
        {
            if (guestReview.Rating is < 0 or > 5)
            {
                throw new ArgumentException("Invalid rating, must be between 0 and 5");
            }
        }

        /// <summary>
        /// Validates if the guest under review has ever rented a residence owned by the host doing the review
        /// </summary>
        /// <remarks>Method will return void if valid, else an exception will be thrown</remarks>
        /// <param name="guestReview">review being validated</param>
        /// <exception cref="ArgumentException">If guest has no approved <c>RentRequest</c> for a residence owned by host of the <c>GuestReview</c></exception>
        private async Task ValidateGuestHasRentResidenceOfHost(GuestReview guestReview)
        {
            var allRentRequests = await _rentalService.GetRentRequestsByGuestIdAsync(guestReview.GuestId);
            var approvedRequestsHostIsOwner = allRentRequests.Where(r =>
                r.Residence.Host.Id == guestReview.HostId && r.Status == RentRequestStatus.APPROVED);
            if (!approvedRequestsHostIsOwner.Any())
            {
                throw new ArgumentException("Guest has never rented any of host's residences before");
            }
        }
    }
}
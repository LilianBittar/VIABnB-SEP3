using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IGuestReviewService
    {
        Task<GuestReview> CreateGuestReviewAsync(GuestReview guestReview);
        Task<GuestReview> UpdateGuestReviewAsync(GuestReview guestReview);
        Task<IEnumerable<GuestReview>> GetAllGuestReviewsByGuestIdAsync(int id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.RentRequest
{
    public partial class GuestReviews
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject] public IGuestReviewService GuestReviewService { get; set; }
        
        private IEnumerable<GuestReview> guestReviews = new List<GuestReview>();
        private bool panelOpenState;
        
        [Parameter]
        public int Id { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            guestReviews = await GuestReviewService.GetAllGuestReviewsByGuestIdAsync(Id);
        }

        private void BackToRentRequest()
        {
            NavigationManager.NavigateTo("RentRequests");
        }
    }
}
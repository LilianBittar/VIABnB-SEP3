using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;

namespace SEP3BlazorT1Client.Pages.RentRequest
{
    public partial class RentRequestHistory
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IRentalService RentalService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private string ErrorMessage = "";
        private IEnumerable<Models.RentRequest> _allRentRequests = new List<Models.RentRequest>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _allRentRequests = await RentalService.GetAllRentRequestsAsync();
            }
            catch (Exception e)
            {
                ErrorMessage = "";
                ErrorMessage = "Something went wrong.. try refreshing the page";
            }
        }

        private void ViewGuestReviews(int id)
        {
            NavigationManager.NavigateTo($"Reviews/{id}");
        }
    }
}
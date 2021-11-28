using System.Collections.Generic;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Data;


namespace SEP3BlazorT1Client.Pages.RentRequest
{
    public partial class RentRequests
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IRentalService RentalService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private IEnumerable<Models.RentRequest> rentRequestList = new List<Models.RentRequest>();
        private bool panelOpenState;

        protected override async Task OnInitializedAsync()
        {
            rentRequestList = await RentalService.GetAllRentRequestsAsync();
        }

        private void ApproveRequest()
        {
            throw new System.NotImplementedException();
        }

        private void RejectRequest()
        {
            throw new System.NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.AdminView
{
    public partial class Administration
    {

        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public IGuestService GuestService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        private IEnumerable<Guest> guestRequestList = new List<Guest>();
        private IEnumerable<Host> hostRequestList = new List<Host>();

        private bool panelOpenState;

        protected override async Task OnInitializedAsync()
        {
            hostRequestList = await HostService.GetAllNotApprovedHostsAsync();
            guestRequestList = await GuestService.GetAllNotApprovedGuests();
        }
        
        private async Task ApproveHost(int hostId)
        {
            var approvedHost = hostRequestList.First(host => host.Id == hostId);
            approvedHost.IsApprovedHost = true;
            await HostService.UpdateHostStatusAsync(approvedHost);
            StateHasChanged();
        }
        
        private async Task RejectHost(int hostId)
        {
            var rejectedHost = hostRequestList.First(host => host.Id == hostId);
            rejectedHost.IsApprovedHost = false;
            await HostService.UpdateHostStatusAsync(rejectedHost);
            StateHasChanged();
        }

        private async Task ApproveGuest(int guestId)
        {
            var approvedGuest = guestRequestList.First(guest => guest.Id == guestId);
            approvedGuest.IsApprovedGuest = true;
            await GuestService.UpdateGuestStatusAsync(approvedGuest);
            StateHasChanged();
        }
        private async Task RejectGuest(int guestId)
        {
            var rejectedGuest = guestRequestList.First(guest => guest.Id == guestId);
            rejectedGuest.IsApprovedGuest = false;
            await GuestService.UpdateGuestStatusAsync(rejectedGuest);
            StateHasChanged();
        }
    }
}
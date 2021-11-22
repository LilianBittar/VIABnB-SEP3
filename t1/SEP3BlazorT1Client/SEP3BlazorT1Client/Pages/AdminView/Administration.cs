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
        
        private IList<Guest> guestRequestList = new List<Guest>();
        private IList<Host> hostRequestList = new List<Host>();

        private bool panelOpenState;

        protected override async Task OnInitializedAsync()
        {
            hostRequestList = await HostService.GetAllNotApprovedHostsAsync();
            guestRequestList = await GuestService.GetAllNotApprovedGuests();
        }
        
        private async Task ValidateHost(int hostId)
        {
            try
            {
                Host hostToUpdate = hostRequestList.First(h => h.Id == hostId);
                if (hostToUpdate == null)
                {
                    Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                    throw new Exception("Host cant be found");
                }
                await HostService.UpdateHostStatusAsync(hostToUpdate);
                hostRequestList.Remove(hostToUpdate);
            }
            catch (Exception e)
            {
                Console.WriteLine("Here...............................................");
                throw;
            }
            /*Host test = new Host()
            {
                Id = 5,
                FirstName = "Kutaiba",
                LastName = "Kashmar",
                Email = "kkashmar94.kk@gmail.com",
                PhoneNumber = "91640761",
                Password = "Test@test231",
                Cpr = "11111111111",
                IsApprovedHost = false,
                ProfileImageUrl = "no"
            };
            await HostService.UpdateHostStatusAsync(test);*/
        }
        private async Task ValidateGuest(int guestId)
        {
            await GuestService.UpdateGuestStatusAsync(guestRequestList.First(guest => guest.Id == guestId));
        }

    }
}
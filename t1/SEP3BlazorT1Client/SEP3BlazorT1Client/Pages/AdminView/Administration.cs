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
    //Todo implement methods. Change from dummy data to AdministrationService. Add submit buttons
    public partial class Administration
    {

        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        private IList<Guest> guestRequestList = new List<Guest>();
        private IList<Host> hostRequestList = new List<Host>();

        private bool panelOpenState;

        protected override async Task OnInitializedAsync()
        {
            hostRequestList = await HostService.GetAllNotApprovedHostsAsync();
        }
        
        private Task ValidateHost()
        {
            throw new NotImplementedException();
        }
        private Task ValidateGuest()
        {
            throw new NotImplementedException();
        }

    }
}
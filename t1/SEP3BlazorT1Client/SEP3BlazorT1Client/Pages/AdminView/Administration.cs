using System;
using System.Collections.Generic;
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
        [Inject] public  IAdministrationService AdministrationService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        
        private IList<GuestRegistrationRequest> guestRequestList = new List<GuestRegistrationRequest>();
        private IList<HostRegistrationRequest> hostRequestList = new List<HostRegistrationRequest>();

        private bool panelOpenState;

        private Task ValidateHost()
        {
            throw new NotImplementedException();
        }
        private Task ValidateGuest()
        {
            throw new NotImplementedException();
        }

        protected override async Task OnInitializedAsync()
        {
            hostRequestList.Add(new HostRegistrationRequest()
            {
                Id = 1,
                CprNumber = "111111-1111",
                PersonalImage = "Image1",
                Status = RequestStatus.NotAnswered
            });    
            hostRequestList.Add(new HostRegistrationRequest()
            {
                Id = 2,
                CprNumber = "222222-2222",
                PersonalImage = "Image2",
                Status = RequestStatus.NotAnswered
            });    
            hostRequestList.Add(new HostRegistrationRequest()
            {
                Id = 3,
                CprNumber = "333333-3333",
                PersonalImage = "Image3",
                Status = RequestStatus.NotAnswered
            });
            guestRequestList.Add(new GuestRegistrationRequest()
            {
                Id = 1,
                Host = new Host()
                {
                    Email = "test1@test.test",
                    FirstName = "Name1",
                    HostReviews = null,
                    Id = 1,
                    IsApprovedHost = false,
                    LastName = "Last",
                    Password = "1234",
                    PhoneNumber = "123456",
                    ProfileImageUrl = "url1"
                },
                Status = RequestStatus.NotAnswered,
                StudentIdImage = "Image1",
                StudentNumber = 1
            });
            guestRequestList.Add(new GuestRegistrationRequest()
            {
                Id = 2,
                Host = new Host()
                {
                    Email = "test2@test.test",
                    FirstName = "Name2",
                    HostReviews = null,
                    Id = 2,
                    IsApprovedHost = false,
                    LastName = "Last2",
                    Password = "1234",
                    PhoneNumber = "123456",
                    ProfileImageUrl = "url2"
                },
                Status = RequestStatus.NotAnswered,
                StudentIdImage = "Image2",
                StudentNumber = 2
            });
            guestRequestList.Add(new GuestRegistrationRequest()
            {
                Id = 3,
                Host = new Host()
                {
                    Email = "test3@test.test",
                    FirstName = "Name3",
                    HostReviews = null,
                    Id = 1,
                    IsApprovedHost = false,
                    LastName = "Last3",
                    Password = "1234",
                    PhoneNumber = "123456",
                    ProfileImageUrl = "url3"
                },
                Status = RequestStatus.NotAnswered,
                StudentIdImage = "Image3",
                StudentNumber = 3
            });
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;
//Todo Validation works by getting data from t3. Find a way to use the AuthenticationStateProvider. Consider making admin a child of host. Ask group first  
namespace SEP3BlazorT1Client.Pages.AdminView
{
    public partial class AdminLogin
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IAdministrationService AdministrationService { get; set; }

        private string email;
        private string password;
        private string errorMessage;

        public async Task LoginAsAdmin()
        {
            errorMessage = "";
            Administrator admin = null;
            try
            {
               admin = await AdministrationService.ValidateAdmin(email, password);
               if (admin != null)
               {
                   email = "";
                   password = "";
                   NavigationManager.NavigateTo("UserRequests");
               }
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
        }
    }
}
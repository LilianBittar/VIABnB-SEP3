using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3BlazorT1Client.Authentication;
using SEP3BlazorT1Client.Data;
namespace SEP3BlazorT1Client.Pages.AdminView
{
    public partial class AdminLogin
    {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IAdministrationService AdministrationService { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private string _email;
        private string _password;
        private string _errorMessage;

        private async Task LoginAsAdmin()
        {
            _errorMessage = "";
            try
            {
                await ((CustomAuthenticationStateProvider) AuthenticationStateProvider).ValidateLogin(_email, _password);
                _email = "";
                _password = "";
                NavigationManager.NavigateTo("/UserRequests");
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
            }
        }

        public async Task AdminLogout()
        {
            _errorMessage = "";
            _email = "";
            _password = "";
            try
            {
                ((CustomAuthenticationStateProvider) AuthenticationStateProvider).Logout();
                NavigationManager.NavigateTo("/AdminLogin");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
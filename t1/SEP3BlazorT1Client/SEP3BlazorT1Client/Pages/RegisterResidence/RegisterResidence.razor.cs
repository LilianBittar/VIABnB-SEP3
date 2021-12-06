using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;
using SEP3BlazorT1Client.ViewModels;

namespace SEP3BlazorT1Client.Pages.RegisterResidence
{
    public partial class RegisterResidence
    {
        [Inject] public MatDialogService MatDialogService { get; set; }

        [Inject] public IResidenceService ResidenceService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IFacilityService FacilityService { get; set; }
        [Inject] public IHostService HostService { get; set; }
        [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }


        public EditContext FormEditContextResidence { get; set; }
        public EditContext FormEditContextAddress { get; set; }

        private Residence _newResidence;


        public string Name { get; set; }
        private bool _showFacilityDialog = false;
        private IEnumerable<Facility> _allFacilities = new List<Facility>();

        private Facility _facilityToBeAdded = new Facility();
        private Address _newResidenceAddress = new Address() {City = new City()};

        private string _registerResidenceErrorMessage = "";

        protected override async Task OnInitializedAsync()
        {
            _newResidence = new Residence()
            {
                Rules = new List<Rule>(),
                Facilities = new List<Facility>(),
                AvailableFrom = DateTime.MaxValue,
                AvailableTo = DateTime.MaxValue,
                Address = new Address()
                {
                    City = new City()
                },
            };
            FormEditContextResidence = new EditContext(_newResidence);
            FormEditContextAddress = new EditContext(_newResidenceAddress);
            _allFacilities = await FacilityService.GetAllFacilities();
            Console.WriteLine(JsonConvert.SerializeObject(_allFacilities));
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            StateHasChanged();
            if (user.Identity.IsAuthenticated)
            {
                var host = await HostService.GetHostByEmail(user.Claims
                    .FirstOrDefault(c => c.Type.ToString() == "email")
                    .Value);
                _newResidence.Host = host;
                StateHasChanged();
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }

        private async void AddNewRule()
        {
            Rule newRule = new Rule()
            {
                Description = await MatDialogService.PromptAsync("Enter rule", "")
            };

            if (!string.IsNullOrEmpty(newRule.Description))
            {
                _newResidence.Rules.Add(newRule);
            }

            StateHasChanged();
        }

        private void OpenAddFacilityDialog()
        {
            _facilityToBeAdded.Name = null;
            _showFacilityDialog = true;
        }

        private void AddFacility()
        {
            Console.WriteLine(_facilityToBeAdded.Name);
            var newFacility = _allFacilities.FirstOrDefault(f => f.Name == _facilityToBeAdded.Name);
            if (newFacility != null && !string.IsNullOrEmpty(_facilityToBeAdded.Name))
            {
                _newResidence.Facilities.Add(
                    new Facility() {Id = newFacility.Id, Name = newFacility.Name});
                Console.WriteLine(newFacility.Id);
                _showFacilityDialog = false;
            }

            StateHasChanged();
        }

        private async Task RegisterNewResidence()
        {
            var validationContext = new ValidationContext(_newResidenceAddress, null, null);
            var validationResults = new List<ValidationResult>();
            _newResidence.Address = _newResidenceAddress;
            TriggerValidation();
            bool residenceIsValid =
                Validator.TryValidateObject(_newResidenceAddress, validationContext, validationResults, true);
            if (residenceIsValid)
            {
                try
                {
                    await ResidenceService.CreateResidenceAsync(_newResidence);
                    // ResetModels();

                    NavigationManager.NavigateTo("/hostresidences");
                }
                catch (ArgumentException e)
                {
                    System.Console.WriteLine($"{this} ArgumentException Caught");
                    _registerResidenceErrorMessage = e.Message;
                }
            }
        }

        private void TriggerValidation()
        {
            FormEditContextResidence.Validate();
            FormEditContextAddress.Validate();
            PrintDebugMessages();
            StateHasChanged();
        }

        private void ResetModels()
        {
            _newResidenceAddress = new Address();
            _newResidence = new Residence()
            {
                Rules = new List<Rule>(),
                Facilities = new List<Facility>(),
                AvailableFrom = DateTime.MaxValue,
                AvailableTo = DateTime.MaxValue,
                Address = new Address() {City = new City()}
            };
        }

        private void PrintDebugMessages()
        {
            System.Console.WriteLine($"Residence address: {JsonConvert.SerializeObject(_newResidenceAddress)}");
            System.Console.WriteLine($"Residence: {JsonConvert.SerializeObject(_newResidence)}");
            System.Console.WriteLine("Validation triggered");
            System.Console.WriteLine($"Address is valid: {FormEditContextAddress.Validate()}");
            System.Console.WriteLine($"Residence is valid: {FormEditContextResidence.Validate()}");
        }
    }
}
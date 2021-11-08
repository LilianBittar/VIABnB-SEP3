using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
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

        // [Inject]
        // public RegisterResidenceViewModel ViewModel { get; set; }
        [Inject]
        public IResidenceService ResidenceService { get; set; }


        public EditContext FormEditContextResidence { get; set; }
        public EditContext FormEditContextAddress { get; set; }

        private Residence _newResidence;



        private string _residenceType ="";
        public string Name { get; set; }
        private bool _showFacilityDialog = false;
        private IList<Facility> _allFacilities = new List<Facility>() {new Facility() {Name = "Wifi"}};
        private IList<string> _allResidenceTypes = new List<string>(); 

        private Facility _facilityToBeAdded = new Facility();
        private Address _newResidenceAddress = new Address(); 

        protected override async Task OnInitializedAsync()
        {

            // TODO: Fetch residence types on mount
            // Subscribing to the ViewModel's PropertyChanged event
            // Everytime a ViewModel property changes, then StateHasChanged gets invoked, 
            // such that View's state reflects ViewModel's state
            // ViewModel.PropertyChanged += async (sender, e) =>
            // {
            //     await InvokeAsync(() =>
            //     {
            //         StateHasChanged();
            //     });
            // };
            _newResidence = new Residence()
            {
                Rules = new List<Rule>(),
                Facilities = new List<Facility>(),
                AvailableFrom = DateTime.Now,
                AvailableTo = DateTime.Now,
                Address = new Address()
            };
            FormEditContextResidence = new EditContext(_newResidence);
            FormEditContextAddress = new EditContext(_newResidenceAddress);
            await base.OnInitializedAsync();
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
            if (!string.IsNullOrEmpty(_facilityToBeAdded.Name))
            {
            _newResidence.Facilities.Add(_facilityToBeAdded);
            _showFacilityDialog = false;
            }
            StateHasChanged(); 

        }

        private async void RegisterNewResidence()
        {
            TriggerValidation(); 
            var validationContext = new ValidationContext(_newResidenceAddress, null, null);
            var validationResults = new List<ValidationResult>();
            bool residenceIsValid = Validator.TryValidateObject(_newResidenceAddress, validationContext, validationResults, true);
            validationResults.ForEach(r => System.Console.WriteLine($"Error: {r}"));
            //     if (residenceIsValid)
            //     {
            //         await ResidenceService.CreateResidenceAsync(_newResidence);
            //     }
            }

            private void TriggerValidation()
        {
            FormEditContextResidence.Validate();
            FormEditContextAddress.Validate();
            System.Console.WriteLine(JsonConvert.SerializeObject(_newResidence));
            System.Console.WriteLine("Validation triggered");
            System.Console.WriteLine(FormEditContextAddress.Validate());
            System.Console.WriteLine(FormEditContextResidence.Validate());
            StateHasChanged();
        }
     
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;
using SEP3BlazorT1Client.ViewModels;

namespace SEP3BlazorT1Client.Pages.RegisterResidence
{
    public partial class RegisterResidence
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
    
        [Inject]
        public RegisterResidenceViewModel ViewModel { get; set; }

        public EditContext FormEditContext { get; set; }



        public string Name { get; set; }
        private bool _showFacilityDialog = false;

        private string _residenceType;
        private Facility _facilityToBeAdded = new Facility();


        protected override async Task OnInitializedAsync()
        {
            // Subscribing to the ViewModel's PropertyChanged event
            // Everytime a ViewModel property changes, then StateHasChanged gets invoked, 
            // such that View's state reflects ViewModel's state
            ViewModel.PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            };
            FormEditContext = new EditContext(ViewModel.ResidenceToBeAdded);
            await base.OnInitializedAsync();
        }

        private async void AddNewRule()
        {
            Rule newRule = new Rule()
            {
                Description = await MatDialogService.PromptAsync("Enter rule", "")
            };

            ViewModel.AddNewRule(newRule); 
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
            ViewModel.ResidenceToBeAdded.Facilities.Add(_facilityToBeAdded);
            _showFacilityDialog = false;
            }
        }

        private async void RegisterNewResidence()
        {
            await ViewModel.RegisterResidenceAsync();
        }

        private void TriggerValidation()
        {
            FormEditContext.Validate(); 
        }
     
    }
}
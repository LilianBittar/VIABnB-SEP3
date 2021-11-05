using System;
using System.Collections.Generic;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using SEP3BlazorT1Client.Data;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Pages.RegisterResidence
{
    public partial class RegisterResidence
    {
        [Inject] public MatDialogService MatDialogService { get; set; }
        [Inject]
        public IResidenceService ResidenceService { get; set; }
        
        

        private bool _showFacilityDialog = false;

        private Residence _residenceToBeAdded = new Residence()
        {
            Address = new Address(), Facilities = new List<Facility>(), Rules = new List<Rule>()
        };

        private string _residenceType;
        private IList<string> _residenceTypes = new List<string>() {"hej", "hej2"};
        private IList<Facility> _allFacilities = new List<Facility>() {new Facility() {Name = "Wifi"}};
        private Facility _facilityToBeAdded = new Facility();

        private async void AddNewRule()
        {
            Rule newRule = new Rule()
            {
                Description = await MatDialogService.PromptAsync("Enter rule", "")
            };

            if (!string.IsNullOrEmpty(newRule.Description))
            {
                _residenceToBeAdded.Rules.Add(newRule);
                Console.WriteLine(_residenceToBeAdded.Rules.Count);
                StateHasChanged();
            }
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
            _residenceToBeAdded.Facilities.Add(_facilityToBeAdded);
            _showFacilityDialog = false;
            StateHasChanged();
            }
        }

        private async void RegisterNewResidence()
        {
            await ResidenceService.CreateResidenceAsync(_residenceToBeAdded); 
        }
    }
}
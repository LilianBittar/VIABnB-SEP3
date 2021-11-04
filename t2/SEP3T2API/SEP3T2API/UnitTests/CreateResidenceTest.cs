using System.Collections.Generic;
using HotChocolate.Types.Relay;
using NUnit.Framework;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services;

namespace UnitTests
{
    [TestFixture]
    public class CreateResidenceTest
    {
        private IResidenceService residenceService;
        private IResidenceRepository residenceRepository;
        private Address address;
        private IList<Facility> facilities;
        private IList<Rule> rules;
        private Residence residence;

        [SetUp]
        public void SetUp()
        {
            residenceRepository = new ResidenceRepositoryImpl();
            residenceService = new ResidenceServiceImpl(residenceRepository);
            
            address = new Address()
            {
                Id = 1,
                StreetName = "StreetNameTest",
                HouseNumber = "1A",
                CityName = "CityTest",
                StreetNumber = "2A",
                ZipCode = 1111
            };
            
            facilities = new List<Facility>();
            facilities.Add(new Facility
            {
                Name = "FacilityTest"
            });
            
            rules = new List<Rule>();
            rules.Add(new Rule()
            {
                Description = "DescriptionTest"
            });
            
            residence = new Residence()
            {
                Id = 1,
                Address = address,
                Description = "DescriptionTest",
                Type = "TypeTest",
                AverageRating = 1.5,
                IsAvailable = false,
                PricePerNight = 100.5,
                Rules = rules,
                Facilities = facilities
            };
        }
    }
}
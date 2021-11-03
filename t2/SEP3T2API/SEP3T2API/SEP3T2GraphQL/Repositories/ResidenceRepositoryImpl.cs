using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public class ResidenceRepositoryImpl: IResidenceRepository
    {
        public async Task<Residence> GetResidenceById(int id)
        {
            return new Residence()
            {
                Id = 1, Address = new Address()
                {
                    Id = 1, StreetName = "Bobstreet", CityName = "BobCity", HouseNumber = "Bob1", StreetNumber = "1",
                    ZipCode = 8700
                },
                Description = "BOB",
                Type = "Bob",
                AverageRating = 10,
                IsAvailable = false,
                PricePerNight = 2000000,
            }; 
        }

        public Task<Residence> CreateResidenceAsync(Residence residence)
        {
            //TODO: Make Http request to T3 REST API
            return null; 
        }
    }
}
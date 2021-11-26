using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlFacilityService : IFacilityService
    {
        public Task<Facility> CreateFacility(Facility facility)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Facility>> GetAllFacilities()
        {
            throw new System.NotImplementedException();
        }

        public Task<Facility> GetFacilityById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IResidenceService
    {
        Task<Residence> GetResidenceAsync(int id);
        Task<Residence> CreateResidenceAsync(Residence residence);

        Task<List<Residence>> GetResidenceByHostId(int Id);
        Task<IList<Residence>> GetAllAvailableResidences(); 
    }
}
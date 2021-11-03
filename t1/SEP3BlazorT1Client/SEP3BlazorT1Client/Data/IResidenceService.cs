using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IResidenceService
    {
        Task<Residence> GetResidenceAsync(int id);
        Task<Residence> CreateResidenceAsync(Residence residence);

    }
}
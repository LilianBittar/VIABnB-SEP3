using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IHostService
    {
        Task<Host> RegisterHostAsync(Host host);
        Task<Host> ValidateHostAsync(string email, string password);
    }
}
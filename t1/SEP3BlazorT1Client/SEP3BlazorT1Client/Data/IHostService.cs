using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data
{
    public interface IHostService
    {
        Task<Host> RegisterHostAsync(Host host);
        Task<Host> ValidateHostAsync(string email, string password);
        Task<Host> GetHostByEmail(string email);
        Task<Host> GetHostById(int id);
        Task<List<Host>> GetAllNotApprovedHostsAsync();
        Task<Host> UpdateHostStatusAsync(Host host);
        Task<Host> UpdateHost(Host host);

    }
}
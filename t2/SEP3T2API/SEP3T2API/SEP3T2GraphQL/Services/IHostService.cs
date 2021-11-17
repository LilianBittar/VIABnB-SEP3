using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IHostService
    {
        Task<Host> UpdateHost(Host host);
        Task<Host> RegisterHostAsync(Host host);
        Task<Host> ValidateHostAsync(Host host);
        Task<Host> GetHostByEmail(string email);
        Task<Host> GetHostById(int id);
    }
}
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IHostService
    {
        Task<Host> RegisterHostAsync(Host host);
        Task<Host> ValidateHostAsync(Host host);
    }
}
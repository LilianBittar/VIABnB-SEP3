using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IHostRepository
    {
        Task<Host> RegisterHostAsync(Host host);
    }
}
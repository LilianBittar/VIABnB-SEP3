using System.Threading.Tasks;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl
{
    public class GraphQlHostService : IHostService
    {
        public Task<Host> RegisterHostAsync(Host host)
        {
            throw new System.NotImplementedException();
        }

        public Task<Host> ValidateHostAsync(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
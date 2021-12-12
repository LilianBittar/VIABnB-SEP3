using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.HostValidation
{
    public interface IHostValidation
    {
        Task<bool> IsValidHost(Host host);
    }
}
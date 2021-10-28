using System.Threading.Tasks;
using ConceptMessageService;

namespace SEP3T2RESTApi.Data
{
    public interface IConceptService
    {
       public Task<conceptMessage> FetchConceptMessageAsync(int id);
    }
}
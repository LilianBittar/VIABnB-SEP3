using System.Threading.Tasks;
using SEP3T2RESTApi.Model;

namespace SEP3T2RESTApi.Data
{
    public interface IConceptService
    {
       public Task<ConceptMessage> FetchConceptMessageAsync(int id);
    }
}
using ConceptMessageService;
using System;
using System.Threading.Tasks;

namespace SEP3T2RESTApi.Data.Impl
{
    public class ConceptServiceImpl : IConceptService
    {
        
        
        public async Task<conceptMessage> FetchConceptMessageAsync(int id)
        {
            ConceptMessageServiceClient client = new ConceptMessageServiceClient();
            conceptMessage conceptMessage = await client.getConceptMessageAsync(id);
         return conceptMessage;
        }
    }
}
using System;
using System.Threading.Tasks;
using SEP3T2RESTApi.Model;

namespace SEP3T2RESTApi.Data.Impl
{
    public class ConceptServiceImpl : IConceptService
    {
        private ConceptMessage conceptMessage = new ConceptMessage();
        
        
        public async Task<ConceptMessage> FetchConceptMessageAsync(int id)
        {
         //   conceptMessage.message = t3.ConceptActivation(ID);
         conceptMessage.ID = id;
         return conceptMessage;
        }
    }
}
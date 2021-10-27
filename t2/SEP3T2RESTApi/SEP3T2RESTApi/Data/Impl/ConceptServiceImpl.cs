using System;
using SEP3T2RESTApi.Model;

namespace SEP3T2RESTApi.Data.Impl
{
    public class ConceptServiceImpl : IConceptService
    {
        private ConceptMessage conceptMessage = new ConceptMessage();
        
        
        public ConceptMessage ConceptActivation(int ID)
        {
            conceptMessage.message = t3.ConceptActivation(ID);
        }
    }
}
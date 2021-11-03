
using System;

namespace SEP3T2RESTApi.Data.Impl
{
    public partial class ConceptServiceImpl : IConceptService
    {
        public void CreateMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
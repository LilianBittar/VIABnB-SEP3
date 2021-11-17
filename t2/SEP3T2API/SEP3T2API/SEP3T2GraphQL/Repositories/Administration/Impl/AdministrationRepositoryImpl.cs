using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories.Administration.Impl
{
    public class AdministrationRepositoryImpl : IAdministrationRepository
    {
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;

        public AdministrationRepositoryImpl()
        {
            client = new HttpClient();
        }
    }
}
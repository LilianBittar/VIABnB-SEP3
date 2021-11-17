using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.Types;
using HotChocolate;
using SEP3T2GraphQL.Graphql.Types;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Graphql
{
    public class HostRequestQuery : ObjectGraphType<object>
    {
        /*public HostRequestQuery([Service] IHostRegistrationRequestRepository hostRegistrationRequestRepository)
        {
            Name = "Query for host request";
            Description = "The query to retrieve host request data";

            FieldAsync<HostRequestObject, List<HostRegistrationRequest>>
            (
                "HostRequest",
                "Gets a list of host requests",
                resolve: context => new Task<List<HostRegistrationRequest>?>(hostRegistrationRequestRepository.GetAllHostRegistrationRequests())
            );
        }*/
    }
}
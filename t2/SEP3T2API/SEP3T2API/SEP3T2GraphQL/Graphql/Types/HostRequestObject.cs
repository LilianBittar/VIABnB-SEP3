using GraphQL.Types;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Graphql.Types
{
    public class HostRequestObject : ObjectGraphType<HostRegistrationRequest>
    {
        public HostRequestObject()
        {
            Name = nameof(HostRegistrationRequest);
            Description = "HostRequest";

            Field(h => h.Id).Description("Request id");
            Field(h => h.PersonalImage).Description("Host image");
            Field(h => h.CprNumber).Description("Host CPR number");
            Field(h => h.Status).Description("Request staus");
        }
    }
}
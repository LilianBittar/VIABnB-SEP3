using GraphQL.Types;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Graphql.Types
{
    public class FacilityObject : ObjectGraphType<Facility>
    {
        public FacilityObject()
        {
            Name = nameof(Facility);
            Description = "Facility of the Residence";
            Field(f => f.Name).Description("Name of the facility"); 
        }
    }
}
using GraphQL.Types;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Graphql.Types
{
    public class ResidenceObject : ObjectGraphType<Residence>
    {
        public ResidenceObject()
        {
            Name = nameof(Residence);
            Description = "Residence";

            Field(r => r.Id).Description("Id of the residence");
            Field(r => r.AverageRating).Description("Average Rating of the residence"); 
            Field(r => r.Type).Description("The Type of residence");
            Field(r => r.Description).Description("Description of the residence");
            Field(r => r.IsAvailable).Description("Describes if the residence is available");
            Field(r => r.PricePerNight).Description("The prices per night in DKK"); 
            Field(
                name: "Address",
                description: "Address of the Residence",
                type: typeof(ObjectGraphType<AddressObject>),
                resolve: r => r.Source.Address
            );
            Field(
                name: "Rules",
                description: "A collection of Rules",
                type: typeof(ListGraphType<RuleObject>),
                resolve: r => r.Source.Rules
            ); Field(
                name: "Facilities",
                description: "A collection of Facilities",
                type: typeof(ListGraphType<FacilityObject>),
                resolve: r => r.Source.Facilities
            );

        }
    }
}
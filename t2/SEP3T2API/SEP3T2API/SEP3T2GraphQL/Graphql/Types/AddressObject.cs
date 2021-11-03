using GraphQL.Types;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Graphql.Types
{
    public class AddressObject : ObjectGraphType<Address>
    {
        public AddressObject()
        {
            Name = nameof(Address);
            Description = "A residence";
            Field(a => a.Id).Description("Id of the address");
            Field(a => a.CityName).Description("City name");
            Field(a => a.HouseNumber).Description("House number");
            Field(a => a.StreetName).Description("Street name");
            Field(a => a.StreetNumber).Description("Street number");
            Field(a => a.ZipCode).Description("Zipcode");
            
        }
    }
}
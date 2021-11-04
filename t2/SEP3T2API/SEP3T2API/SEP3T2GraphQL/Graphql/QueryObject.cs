using GraphQL;
using GraphQL.Types;
using HotChocolate;
using SEP3T2GraphQL.Graphql.Types;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;

namespace SEP3T2GraphQL.Graphql
{
    public class QueryObject : ObjectGraphType<object>
    {
        public QueryObject([Service] IResidenceRepository residenceRepository)
        {
            Name = "Queries";
            Description = "The base query for all the entities in our object graph.";

            FieldAsync<ResidenceObject, Residence>(
                "Residence",
                "Gets a residence by ID.",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                    }),
                context => residenceRepository.GetResidenceByIdAsync(context.GetArgument<int>("id")));
        }
    }
}
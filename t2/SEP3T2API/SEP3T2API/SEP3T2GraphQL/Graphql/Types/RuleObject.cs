using GraphQL.Types;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Graphql.Types
{
    public class RuleObject : ObjectGraphType<Rule>
    {
        public RuleObject()
        {
            Name = nameof(Rule);
            Description = "Rule of the Residence";

            Field(r => r.Description).Description("Describes the rule"); 
        }
    }
}
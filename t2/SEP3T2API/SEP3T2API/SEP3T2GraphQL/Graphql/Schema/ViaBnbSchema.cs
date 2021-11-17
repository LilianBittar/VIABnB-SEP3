
using System;

namespace SEP3T2GraphQL.Graphql.Schema
{
    public class ViaBnbSchema : GraphQL.Types.Schema
    {
        public ViaBnbSchema(QueryObject query, IServiceProvider sp): base(sp)
        {
            Query = query;
        }
    }
}
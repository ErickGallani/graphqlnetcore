
namespace GraphQLTester.Schemas
{
    using System;
    using GraphQL.Types;
    using GraphQLTester.Queries;

    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (StudentQuery)resolveType(typeof(StudentQuery));
        }
    }
}

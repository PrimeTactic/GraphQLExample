using GraphQL;

namespace Data.GraphQL.Schema
{
    public class Schema : global::GraphQL.Types.Schema
    {
        public Schema(Query query, Mutation mutation, Subscription subscription, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            Subscription = subscription;
            DependencyResolver = resolver;
        }
    }
}

using HotChocolate;
using HotChocolate.Types;

namespace Poc_GraphQL.Domain.Entities
{
    public class CustomerEntity
    {
        [GraphQLType(typeof(NonNullType<IdType>))]
        public int Id { get; set; }
        [GraphQLNonNullType]
        public string? Name { get; set; }
        [GraphQLNonNullType]
        public DateTime Birth { get; set; }
    }
}

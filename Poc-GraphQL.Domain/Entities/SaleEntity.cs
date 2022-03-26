using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Domain.Entities
{
    public class SaleEntity
    {
        public int Id { get; set; }
        [GraphQLNonNullType]
        public int Price { get; set; }
        [GraphQLType(typeof(NonNullType<StringType>))]
        public string? Product { get; set; }
        [GraphQLNonNullType]
        public int CustomerId { get; set; }
    }
}

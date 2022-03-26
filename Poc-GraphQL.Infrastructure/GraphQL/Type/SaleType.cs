using HotChocolate.Types;
using Poc_GraphQL.Domain.Entities;
using Poc_GraphQL.Infrastructure.GraphQL.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Infrastructure.GraphQL.Type
{
    public class SaleType : ObjectType<SaleEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<SaleEntity> descriptor)
        {
            descriptor.Field(b => b.Id).Type<IdType>();
            descriptor.Field(b => b.Product).Type<StringType>();
            descriptor.Field(b => b.Price).Type<IntType>();
            descriptor.Field<CustomerResolver>(t => t.GetCustomer(default, default));
        }
    }
}

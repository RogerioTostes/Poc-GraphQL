using HotChocolate.Types;
using Poc_GraphQL.Domain.Entities;
using Poc_GraphQL.Infrastructure.GraphQL.Resolver;

namespace Poc_GraphQL.Infrastructure.GraphQL.Type
{
    public class CustomerType : ObjectType<CustomerEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<CustomerEntity> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.Birth).Type<DateTimeType>();
            descriptor.Field<SaleResolver>(b => b.GetSales(default, default));
        }
    }
}

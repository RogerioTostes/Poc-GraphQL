using HotChocolate;
using HotChocolate.Resolvers;
using Poc_GraphQL.Domain.Entities;
using Poc_GraphQL.Domain.Gateways;

namespace Poc_GraphQL.Infrastructure.GraphQL.Resolver
{
    public class CustomerResolver
    {
        private readonly ICustomerGateway customerGateway;

        public CustomerResolver([Service] ICustomerGateway customerGateway)
        {
            this.customerGateway = customerGateway;
        }

        public CustomerEntity GetCustomer([Parent] SaleEntity sale, IResolverContext ctx)

        {
            return customerGateway.GetAllCustomers().FirstOrDefault(a => a.Id == sale.CustomerId);
        }
    }
}

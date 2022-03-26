using HotChocolate;
using HotChocolate.Resolvers;
using Poc_GraphQL.Domain.Entities;
using Poc_GraphQL.Domain.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Infrastructure.GraphQL.Resolver
{
    public class SaleResolver
    {
        private readonly ISaleGateway saleGateway;
        public SaleResolver([Service] ISaleGateway saleGateway)
        {
            this.saleGateway = saleGateway;
        }
        public IEnumerable<SaleEntity> GetSales([Parent] CustomerEntity customer, IResolverContext ctx)
        {
            return saleGateway.GetAllSales().Where(b => b.CustomerId == customer.Id);
        }
    }
}

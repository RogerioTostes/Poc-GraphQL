using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using Poc_GraphQL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Infrastructure.GraphQL
{
    public class Subscription
    {

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<List<CustomerEntity>>> OnCustomersGet([Service] ITopicEventReceiver eventReceiver,
           CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, List<CustomerEntity>>("ReturnedCustomers", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<CustomerEntity>> OnCustomerGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, CustomerEntity>("ReturnedCustomer", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<SaleEntity>> OnSalesGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, SaleEntity>("ReturnedSales", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<SaleEntity>> OnSaleGet([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, SaleEntity>("ReturnedSale", cancellationToken);
        }
    }
}

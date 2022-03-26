using HotChocolate;
using HotChocolate.Subscriptions;
using Poc_GraphQL.Domain.Entities;
using Poc_GraphQL.Domain.Gateways;
using Poc_GraphQL.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Infrastructure.GraphQL
{
    public class Query
    {


        public async Task<List<CustomerEntity>>
       GetAllCustomers([Service]
        ICustomerGateway customerGateway,
       [Service] ITopicEventSender eventSender)
        {
            List<CustomerEntity> customers =
            customerGateway.GetAllCustomers();
            await eventSender.SendAsync("ReturnedCustomers",
            customers);
            return customers;
        }

        public async Task<CustomerEntity> GetCustomerById([Service]
        ICustomerGateway customerGateway,
       [Service] ITopicEventSender eventSender, int id)
        {
            CustomerEntity customer =
            customerGateway.GetCustomer(id);
            await eventSender.SendAsync("ReturnedCustomer",
            customer);
            return customer;
        }

        public async Task<List<SaleEntity>>
       GetAllSales([Service] ISaleGateway
       saleGateway,
       [Service] ITopicEventSender eventSender)
        {
            List<SaleEntity> sales =
            saleGateway.GetAllSales();
            await eventSender.SendAsync("ReturnedSales",
            sales);
            return sales;
        }

        public async Task<SaleEntity> GetSaleById([Service]
        ISaleGateway saleGateway,
        [Service] ITopicEventSender eventSender, int id)
        {
            SaleEntity sale =
            saleGateway.GetSale(id);
            await eventSender.SendAsync("ReturnedSale",
            sale);
            return sale;
        }
    }
}

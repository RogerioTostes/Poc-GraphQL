using AutoMapper;
using Poc_GraphQL.Application.Models.Request;
using Poc_GraphQL.Domain.Entities;
using Poc_GraphQL.Domain.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Application.UseCase
{
    public class InsertCustomerUseCaseAsync : IUseCaseAsync<CustomerRequest>
    {
        private readonly ICustomerGateway customerGateway;
        private readonly IMapper mapper;
        public InsertCustomerUseCaseAsync(
            ICustomerGateway customerGateway,
            IMapper mapper
            )
        {
            this.customerGateway = customerGateway;
            this.mapper = mapper;
        }

        public Task ExecuteAsync(CustomerRequest request)
        {
            CustomerEntity entity = mapper.Map<CustomerEntity>(request);
            customerGateway.InsertCustomer(entity);
            return Task.CompletedTask;
        }
    }
    
}

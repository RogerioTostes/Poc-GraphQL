using AutoMapper;
using Poc_GraphQL.Application.Models.Response;
using Poc_GraphQL.Domain.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Application.UseCase
{
    public class GetAllCustomerUseCaseAsync : IUseCaseAsyncR<IEnumerable<CustomerResponse>>
    {
        private readonly ICustomerGateway customerGateway;       
        private readonly IMapper mapper;
        public GetAllCustomerUseCaseAsync(
            ICustomerGateway customerGateway,         
            IMapper mapper
            )
        {
            this.customerGateway = customerGateway;          
            this.mapper = mapper;
        }
        public IEnumerable<CustomerResponse> ExecuteAsync()
        {
            var result = customerGateway.GetAllCustomers();

            return mapper.Map<IEnumerable<CustomerResponse>>(result);
        }
    }
}

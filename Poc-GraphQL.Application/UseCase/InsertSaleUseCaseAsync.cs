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
    public class InsertSaleUseCaseAsync : IUseCaseAsync<SaleRequest>
    {
        private readonly ISaleGateway saleGateway;
        private readonly IMapper mapper;
        public InsertSaleUseCaseAsync(
            ISaleGateway saleGateway,
            IMapper mapper
            )
        {
            this.saleGateway = saleGateway;
            this.mapper = mapper;
        }

        public Task ExecuteAsync(SaleRequest request)
        {
            SaleEntity entity = mapper.Map<SaleEntity>(request);
            saleGateway.InsertSale(entity);
            return Task.CompletedTask;
        }
    }
}

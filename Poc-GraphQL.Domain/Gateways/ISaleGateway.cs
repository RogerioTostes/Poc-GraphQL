using Poc_GraphQL.Domain.Entities;
using Poc_GraphQL.Domain.Gateways.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Domain.Gateways
{
    public interface ISaleGateway : ISaleRepositoryGateway<SaleEntity, int>
    {
    }
}

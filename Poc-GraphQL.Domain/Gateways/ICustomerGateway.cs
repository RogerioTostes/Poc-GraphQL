using Poc_GraphQL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Domain.Gateways
{
    public interface ICustomerGateway : ICustomerRepositoryGateway<CustomerEntity, int>
    {
    }
}

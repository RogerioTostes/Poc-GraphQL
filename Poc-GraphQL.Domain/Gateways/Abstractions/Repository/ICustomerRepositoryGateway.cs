using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Domain.Gateways
{
    public interface ICustomerRepositoryGateway<TEntity, TKey>
    {

        List<TEntity> GetAllCustomers();

        TEntity GetCustomer(TKey key);

        void InsertCustomer(TEntity entity);

    }
}

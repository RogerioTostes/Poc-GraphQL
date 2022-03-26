using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Domain.Gateways.Abstractions.Repository
{
    public interface ISaleRepositoryGateway<TEntity, TKey>
    {
       
        List<TEntity> GetAllSales();
        
        TEntity GetSale(TKey key);
        void InsertSale(TEntity entity);
    }


}

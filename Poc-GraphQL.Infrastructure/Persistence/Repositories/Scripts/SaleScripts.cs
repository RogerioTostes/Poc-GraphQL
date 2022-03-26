using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Infrastructure.Persistence.Repositories.Scripts
{
    public static class SaleScripts
    {
        public static readonly string GET_ALL = @"SELECT id as ID, price as Price, product as Product, customerId as CustomerId
FROM Sale;";
    

    public static readonly string GET_ID = @"SELECT id as ID, price as Price, product as Product, customerId as CustomerId
FROM Sale WHERE id = @id;";

        public static readonly string INSERT = @"INSERT INTO Sale(price,product,customerId) VALUES (@price,@product,@customerId);";
    }
}

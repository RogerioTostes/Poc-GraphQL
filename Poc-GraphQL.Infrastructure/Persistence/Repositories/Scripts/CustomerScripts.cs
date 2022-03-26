using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Infrastructure.Persistence.Repositories.Scripts
{
    public static class CustomerScripts
    {
        public static readonly string GET_ALL = @"SELECT id as Id, name as Name, birth as Birth
FROM Customer;";

        public static readonly string GET_ID = @"SELECT id as Id, name as Name, birth as Birth
FROM Customer WHERE id = @id;";

        public static readonly string INSERT = @"INSERT INTO Customer(name,birth) VALUES (@name,@birth);";
    }
}

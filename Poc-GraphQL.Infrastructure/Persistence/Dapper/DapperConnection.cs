using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Infrastructure.Persistence.Dapper
{
    public class DapperConnection
    {
                private readonly IConfiguration _configuration;

        public DapperConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  DbConnection CreateSqlConnection()
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return connection;
        }

      
    }
}

using Dapper;
using Poc_GraphQL.Domain.Entities;
using Poc_GraphQL.Domain.Gateways;
using Poc_GraphQL.Infrastructure.Persistence.Dapper;
using Poc_GraphQL.Infrastructure.Persistence.Repositories.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_GraphQL.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerGateway
    {
        private readonly DapperConnection dapperConnection;

        public CustomerRepository(DapperConnection dapperConnection)
        {
            this.dapperConnection = dapperConnection;
        }


        public List<CustomerEntity> GetAllCustomers()
        {
            using var connection = dapperConnection.CreateSqlConnection();
            connection.Open();
            var customerEntitys = connection.Query<CustomerEntity>(CustomerScripts.GET_ALL);
            return customerEntitys.ToList();

        }

        public CustomerEntity GetCustomer(int key)
        {
            using var connection = dapperConnection.CreateSqlConnection();
            connection.Open();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", key);
            return connection.QueryFirst<CustomerEntity>(CustomerScripts.GET_ID, dynamicParameters);

        }

        public void InsertCustomer(CustomerEntity entity)
        {
            using var connection = dapperConnection.CreateSqlConnection();
            connection.Open();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@name", entity.Name);
            dynamicParameters.Add("@birth", entity.Birth);
            connection.ExecuteAsync(CustomerScripts.INSERT, dynamicParameters);
        }

        
    }
}


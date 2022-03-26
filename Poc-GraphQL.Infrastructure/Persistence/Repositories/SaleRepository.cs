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
    public class SaleRepository : ISaleGateway
    {
        private readonly DapperConnection dapperConnection;

        public SaleRepository(DapperConnection dapperConnection)
        {
            this.dapperConnection = dapperConnection;
        }

        public List<SaleEntity> GetAllSales()
        {
            using var connection = dapperConnection.CreateSqlConnection();
            connection.Open();
            var sales = connection.Query<SaleEntity>(SaleScripts.GET_ALL);
            return sales.ToList();
        }

        public SaleEntity GetSale(int key)
        {
            using var connection = dapperConnection.CreateSqlConnection();
            connection.Open();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", key);
            return connection.QueryFirst<SaleEntity>(SaleScripts.GET_ID, dynamicParameters);

        }

        public void InsertSale(SaleEntity entity)
        {
            using var connection = dapperConnection.CreateSqlConnection();
            connection.Open();
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@price", entity.Price);
            dynamicParameters.Add("@product", entity.Product);
            dynamicParameters.Add("@customerId", entity.CustomerId);
            connection.ExecuteAsync(SaleScripts.INSERT, dynamicParameters);
        }
    }

}

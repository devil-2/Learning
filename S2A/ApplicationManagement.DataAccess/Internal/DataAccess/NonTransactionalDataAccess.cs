using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApplicationManagement.DataAccess.Internal.DataAccess
{
    internal class NonTransactionalDataAccess
    {
       
        public List<T> Query<T, U>(string storedProcedure, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }
        public List<T> Query<T>(string storedProcedure, string connectionString)
        {
            return Query<T, dynamic>(storedProcedure, new { }, connectionString);
        }
        public async Task<List<T>> QueryAsync<T, U>(string storedProcedure, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<T> rows = await connection.QueryAsync<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }
        public async Task<List<T>> QueryAsync<T>(string storedProcedure, string connectionString)
        {
            return await QueryAsync<T, dynamic>(storedProcedure, new { }, connectionString);
        }
        
        public void Execute<T>(string storedProcedure, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        
        public async Task ExecuteAsync<T>(string storedProcedure, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public U ExecuteScalar<T,U>(string storedProcedure, T parameters, string connectionString)
        {
            U result;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                result = connection.ExecuteScalar<U>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<U> ExecuteScalarAsync<T,U>(string storedProcedure, T parameters, string connectionString)
        {
            U result;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                result = await connection.ExecuteScalarAsync<U>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}

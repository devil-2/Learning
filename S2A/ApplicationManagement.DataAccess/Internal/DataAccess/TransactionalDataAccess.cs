using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationManagement.DataAccess.Internal.DataAccess
{
    internal class TransactionalDataAccess : IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _isClosed = false;
        private readonly string _connectionString;

        public TransactionalDataAccess(string connectionString)
        {
            _connectionString = connectionString;
            BeginTransaction();
            _isClosed = false;

        }

        public void BeginTransaction()
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
            _connection?.Close();
            _isClosed = true;
        }

        public List<T> Query<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

            return rows;
        }
        public List<T> Query<T>(string storedProcedure)
        {
            return Query<T, dynamic>(storedProcedure, new { });
        }

        public async Task<List<T>> QueryAsync<T, U>(string storedProcedure, U parameters)
        {
            IEnumerable<T> rows = await _connection.QueryAsync<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);

            return rows.ToList();
        }
        public async Task<List<T>> QueryAsync<T>(string storedProcedure)
        {
            return await QueryAsync<T, dynamic>(storedProcedure, new { });
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            _connection?.Close();
            _isClosed = true;
        }

        public void Execute<T>(string storedProcedure, T parameters)
        {
            _connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }
        public async Task ExecuteAsync<T>(string storedProcedure, T parameters)
        {
            await _connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public U ExecuteScalar<T, U>(string storedProcedure, T parameters)
        {
            return _connection.ExecuteScalar<U>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public async Task<U> ExecuteScalarAsync<T, U>(string storedProcedure, T parameters)
        {
            return (await _connection.ExecuteScalarAsync<U>(storedProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction));
        }

        public void Dispose()
        {
            try
            {
                if (!_isClosed) Commit();
            }
            catch
            {
                ///
            }
            _transaction = null;
            _connection = null;
        }
    }
}

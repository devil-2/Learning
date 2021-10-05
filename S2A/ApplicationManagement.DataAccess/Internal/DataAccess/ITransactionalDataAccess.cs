using System.Collections.Generic;

namespace ApplicationManagement.DataAccess.Internal.DataAccess
{
    internal interface ITransactionalDataAccess
    {
        void BeginTransaction();
        void Commit();
        List<T> Query<T, U>(string storedProcedure, U parameters);
        List<T> Query<T>(string storedProcedure);
        void Rollback();
        U ExecuteScalar<T, U>(string storedProcedure, T parameters);
        void Execute<T>(string storedProcedure, T parameters);
    }
}
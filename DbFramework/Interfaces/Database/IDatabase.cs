using System.Data;

namespace DbFramework.Interfaces.Database
{
    public interface IDatabase
    {
        IDbConnection CreateConnection();

        IDbCommand GetSqlStringCommand(string query);
        IDbCommand GetStoredProcCommand(string storedProcedureName);

        IDataReader ExecuteReader(IDbCommand command);
        IDataReader ExecuteReader(IDbCommand command, IDbTransaction transaction);

        int ExecuteNonQuery(IDbCommand command);
        int ExecuteNonQuery(IDbCommand command, IDbTransaction transaction);

        object ExecuteScalar(IDbCommand command);
        object ExecuteScalar(IDbCommand command, IDbTransaction transaction);

        void DiscoverParameters(IDbCommand command);
    }
}
using System.Data;

namespace DbFramework.Interfaces
{
    public interface IDbUtils
    {
        IDbConnection CreateConnection(string connectionString);

        IDbCommand GetSqlStringCommand(string query);
        IDbCommand GetStoredProcCommand(string storedProcedureName);

        void DiscoverParameters(IDbCommand command);
        //Task DiscoverParametersAsync(IDbCommand command, CancellationToken cancellationToken);
    }
}
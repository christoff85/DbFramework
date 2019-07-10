using System;
using System.Data;

namespace DbFramework.Interfaces
{
	public interface IDbManager : IDisposable
	{
        bool IsInTransaction { get; }

		void StartConnection();
	    //Task StartConnectionAsync();
        
        int ExecuteNonQuery(IDbCommand command);
	    //Task<int> ExecuteNonQueryAsync(IDbCommand command, CancellationToken cancellationToken);

        TResult ExecuteScalar<TResult>(IDbCommand command);
	    //Task<TResult> ExecuteScalarAsync<TResult>(IDbCommand command, CancellationToken cancellationToken);
        
        IDbReader ExecuteReader(IDbCommand command);
	    //Task<IDbReader> ExecuteReaderAsync(IDbCommand command, CancellationToken cancellationToken);

        IDbCommand GetSqlStringCommand(string query);
	    IDbCommand GetStoredProcCommand(string storedProcedureName);

	    void DiscoverParameters(IDbCommand command);
	    //Task DiscoverParametersAsync(IDbCommand command, CancellationToken cancellationToken);

        void SaveChanges();
	}
}
using System;
using System.Data;
using DbFramework.Interfaces.Database;

namespace DbFramework.Interfaces.ServiceManagers
{
    public interface IDbServiceManager : IDisposable
    {
	    IDatabase Database { get; }
		IDbTransaction DbTransaction { get; }

	    void CreateAndOpenConnection();
		void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

	    IDataReader ExecuteReader(IDbCommand command);
		int ExecuteNonQuery(IDbCommand command);
	    object ExecuteScalar(IDbCommand command);
	    
	}
}
using System;
using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.ServiceManagers
{
    internal abstract class DbServiceManager : IDbServiceManager
    {
		public IDatabase Database { get; }
	    public IDbTransaction DbTransaction { get; internal set; }

		protected IDbConnection DbConnection { get; set; }

	    protected DbServiceManager(IDatabase database) 
		    => Database = database ?? throw new ArgumentNullException(nameof(database));

	    public void CreateAndOpenConnection()
	    {
		    DbConnection = Database.CreateConnection();
		    DbConnection.Open();
		}

	    public abstract void BeginTransaction();
	    public abstract void CommitTransaction();
	    public abstract void RollbackTransaction();

	    public abstract IDataReader ExecuteReader(IDbCommand command);
	    public abstract int ExecuteNonQuery(IDbCommand command);
	    public abstract object ExecuteScalar(IDbCommand command);

		public virtual void Dispose()
	    {
			DbTransaction?.Dispose();
		    DbConnection?.Dispose();
		}
    }
}
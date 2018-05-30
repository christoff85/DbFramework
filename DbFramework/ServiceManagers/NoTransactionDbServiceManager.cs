using System.Data;
using DbFramework.Interfaces.Database;

namespace DbFramework.ServiceManagers
{
    internal class NoTransactionDbServiceManager : DbServiceManager
    {
	    public NoTransactionDbServiceManager(IDatabase database) : base(database) 
		    => DbTransaction = null;

	    public override void BeginTransaction() { }

		public override void CommitTransaction() { }

		public override void RollbackTransaction() { }

		public override IDataReader ExecuteReader(IDbCommand command) 
		    => Database.ExecuteReader(command);

		public override int ExecuteNonQuery(IDbCommand command) 
		    => Database.ExecuteNonQuery(command);

	    public override object ExecuteScalar(IDbCommand command) 
		    => Database.ExecuteScalar(command);
    }
}
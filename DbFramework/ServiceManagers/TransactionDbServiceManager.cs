using System.Data;
using DbFramework.Interfaces.Database;

namespace DbFramework.ServiceManagers
{
	internal class TransactionDbServiceManager : DbServiceManager
	{
		private IsolationLevel IsolationLevel { get; }

		public TransactionDbServiceManager(IDatabase database) : this(database, IsolationLevel.ReadCommitted)
		{
		}

		public TransactionDbServiceManager(IDatabase database, IsolationLevel isolationLevel) : base(database)
		{
			IsolationLevel = isolationLevel;
		}

		public override void BeginTransaction() 
			=> DbTransaction = DbConnection.BeginTransaction(IsolationLevel);

		public override void CommitTransaction()
		{
			DbTransaction.Commit();
			CleanTransactionState();
		}

		public override void RollbackTransaction()
		{
			DbTransaction.Rollback();
			CleanTransactionState();
		}

		public override IDataReader ExecuteReader(IDbCommand command)
			=> Database.ExecuteReader(command, DbTransaction);

		public override int ExecuteNonQuery(IDbCommand command)
			=> Database.ExecuteNonQuery(command, DbTransaction);

		public override object ExecuteScalar(IDbCommand command)
			=> Database.ExecuteScalar(command, DbTransaction);

		private void CleanTransactionState()
		{
			if (IsolationLevel == IsolationLevel.ReadCommitted) return;
				DbConnection.BeginTransaction().Commit();
		}
	}
}

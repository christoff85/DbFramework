using System.Data;

namespace DbFramework.Interfaces.Factories
{
	public interface IDbManagerFactory
	{
		IDbManager CreateNoTransactionDbManager();
		IDbManager CreateTransactionDbManager();
		IDbManager CreateTransactionDbManager(IsolationLevel isolationLevel);
	    IDbManager CreateTransactionDbManager(IDbTransaction existingTransaction);

	}
}

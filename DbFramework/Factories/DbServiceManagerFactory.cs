using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.Factories;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.ServiceManagers;

namespace DbFramework.Factories
{

	internal class DbServiceManagerFactory : IDbServiceManagerFactory
	{
		public IDbServiceManager CreateNoTransactionDbServiceManager(IDatabase database)
			=> new NoTransactionDbServiceManager(database);

		public IDbServiceManager CreateTransactionDbServiceManager(IDatabase database) 
			=> new TransactionDbServiceManager(database);

		public IDbServiceManager CreateTransactionDbServiceManager(IDatabase database, IsolationLevel isolationLevel)
			=> new TransactionDbServiceManager(database, isolationLevel);
	}
}

using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Interfaces.Factories
{
	internal interface IDbServiceManagerFactory
	{
		IDbServiceManager CreateNoTransactionDbServiceManager(IDatabase database);
		IDbServiceManager CreateTransactionDbServiceManager(IDatabase database);
		IDbServiceManager CreateTransactionDbServiceManager(IDatabase database, IsolationLevel isolationLevel);
	}
}

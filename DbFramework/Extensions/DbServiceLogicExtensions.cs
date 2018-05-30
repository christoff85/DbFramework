using System.Data;
using DbFramework.Factories;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Extensions
{
    public static class DbServiceLogicExtensions
    {
        public static TResult CreateServiceAndExecute<TResult>(this IDbServiceLogic<TResult> logic, IDatabase database) 
	        => DbService.CreateService(database, logic).Execute();

	    public static TResult CreateTransactionServiceAndExecute<TResult>(this IDbServiceLogic<TResult> logic, IDatabase database) 
		    => DbService.CreateTransactionService(database, logic).Execute();

	    public static TResult CreateTransactionServiceAndExecute<TResult>(this IDbServiceLogic<TResult> logic, IDatabase database, IsolationLevel level) 
		    => DbService.CreateTransactionService(database, logic, level).Execute();

	    public static TResult Invoke<TResult>(this IDbServiceLogic<TResult> logic, IDbServiceManager dbServiceManager)
		    => DbServiceComponentInvokerFactory.Create(logic).Invoke(dbServiceManager);
	}
}

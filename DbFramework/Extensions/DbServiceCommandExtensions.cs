using System.Collections.Generic;
using DbFramework.Factories;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Extensions
{
    public static class DbServiceCommandExtensions
    {
        public static IEnumerable<TResult> Invoke<TResult>(this IManyResultCommand<TResult> command, IDbServiceManager dbServiceManager) 
	        => DbServiceComponentInvokerFactory.Create(command).Invoke(dbServiceManager);

	    public static int Invoke(this INonQueryCommand command, IDbServiceManager dbServiceManager)
		    => DbServiceComponentInvokerFactory.Create(command).Invoke(dbServiceManager);

	    public static TResult Invoke<TResult>(this INonQueryCommand<TResult> command, IDbServiceManager dbServiceManager) 
		    => DbServiceComponentInvokerFactory.Create(command).Invoke(dbServiceManager);

	    public static TResult Invoke<TResult>(this IScalarCommand<TResult> command, IDbServiceManager dbServiceManager)
		    => DbServiceComponentInvokerFactory.Create(command).Invoke(dbServiceManager);

	    public static TResult Invoke<TResult>(this ISingleResultCommand<TResult> command, IDbServiceManager dbServiceManager) 
		    => DbServiceComponentInvokerFactory.Create(command).Invoke(dbServiceManager);

	    public static TResult Invoke<TResult>(this ICustomHandlerCommand<TResult> command, IDbServiceManager dbServiceManager) 
		    => DbServiceComponentInvokerFactory.Create(command).Invoke(dbServiceManager);

	    public static bool Invoke(this IResultExistsCheckCommand command, IDbServiceManager dbServiceManager)
		    => DbServiceComponentInvokerFactory.Create(command).Invoke(dbServiceManager);
    }
}

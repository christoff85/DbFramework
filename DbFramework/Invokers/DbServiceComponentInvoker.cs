using System;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;
using log4net;


namespace DbFramework.Invokers
{
    public abstract class DbServiceComponentInvoker<TResult> : IDbServiceComponentInvoker<TResult>
    {
        protected ILog Logger { get; }

	    protected DbServiceComponentInvoker()
        {
	        Logger = LogManager.GetLogger(GetType());
		}

	    public TResult Invoke(IDbServiceManager dbServiceManager)
        {
            var methodName = $"{GetType().Name}.{nameof(Invoke)}({InvokedMemberName()})";
            Logger.DebugFormat("Method invoked: {0}", methodName);

            if (dbServiceManager == null) throw new ArgumentNullException(nameof(dbServiceManager));

		    return Execute(dbServiceManager);
        }

	    protected abstract string InvokedMemberName();

	    protected abstract TResult Execute(IDbServiceManager dbServiceManager);
	}
}

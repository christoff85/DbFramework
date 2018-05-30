using System.Data;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
    public class ScalarCommandInvoker<TResult>
        : DbServiceCommandInvoker<IScalarCommand<TResult>, TResult>, IScalarCommandInvoker<TResult>
    {
        internal ScalarCommandInvoker(IScalarCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbServiceManager dbServiceManager, IDbCommand command)
	        => (TResult)dbServiceManager.ExecuteScalar(command);
    }
}
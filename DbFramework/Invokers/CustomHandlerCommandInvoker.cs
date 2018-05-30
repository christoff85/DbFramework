using System.Data;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
    public class CustomHandlerCommandInvoker<TResult>
        : DbServiceCommandInvoker<ICustomHandlerCommand<TResult>, TResult>, ICustomHandlerCommandInvoker<TResult>
    {
        public CustomHandlerCommandInvoker(ICustomHandlerCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbServiceManager dbServiceManager, IDbCommand command) 
	        => Command.CustomHandler(dbServiceManager, command);
    }
}
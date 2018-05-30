using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.Invokers;
using DbFramework.Invokers;

namespace DbFramework.Factories
{
    public static class DbServiceComponentInvokerFactory
    {
        public static INonQueryCommandInvoker Create(INonQueryCommand serviceCommand) 
	        => new NonQueryCommandInvoker(serviceCommand);

	    public static INonQueryCommandInvoker<TResult> Create<TResult>(INonQueryCommand<TResult> serviceCommand) 
		    => new NonQueryCommandInvoker<TResult>(serviceCommand);

	    public static ISingleResultCommandInvoker<TResult> Create<TResult>(ISingleResultCommand<TResult> serviceCommand)
		    => new SingleResultCommandInvoker<TResult>(serviceCommand);

	    public static IManyResultCommandInvoker<TResult> Create<TResult>(IManyResultCommand<TResult> serviceCommand)
		    => new ManyResultCommandInvoker<TResult>(serviceCommand);

	    public static IScalarCommandInvoker<TResult> Create<TResult>(IScalarCommand<TResult> serviceCommand) 
		    => new ScalarCommandInvoker<TResult>(serviceCommand);

	    public static ICustomHandlerCommandInvoker<TResult> Create<TResult>(ICustomHandlerCommand<TResult> serviceCommand) 
		    => new CustomHandlerCommandInvoker<TResult>(serviceCommand);

	    public static IResultExistsCheckCommandInvoker Create(IResultExistsCheckCommand serviceCommand) 
		    => new ResultExistsCheckCommandInvoker(serviceCommand);

	    public static IDbServiceLogicInvoker<TResult> Create<TResult>(IDbServiceLogic<TResult> serviceLogic)
		    => new DbServiceLogicInvoker<TResult>(serviceLogic);
	}
}
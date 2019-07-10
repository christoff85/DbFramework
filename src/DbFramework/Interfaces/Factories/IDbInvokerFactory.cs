using DbFramework.DbCommands;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Interfaces.Factories
{
	public interface IDbInvokerFactory
	{
		INonQueryCommandInvoker Create(INonQueryCommand serviceCommand);
		IDoesResultExistCommandInvoker Create(IDoesResultExistCommand serviceCommand);
		IManyResultCommandInvoker<TResult> Create<TResult>(IManyResultsCommand<TResult> serviceCommand);
		INonQueryCommandInvoker<TResult> Create<TResult>(INonQueryCommand<TResult> serviceCommand);
		IScalarCommandInvoker<TResult> Create<TResult>(IScalarCommand<TResult> serviceCommand);
		ISingleResultCommandInvoker<TResult> Create<TResult>(ISingleResultCommand<TResult> serviceCommand);
		ISingleResultOrDefaultCommandInvoker<TResult> Create<TResult>(ISingleResultOrDefaultCommand<TResult> serviceCommand);
		IFirstResultCommandInvoker<TResult> Create<TResult>(IFirstResultCommand<TResult> serviceCommand);
		IFirstResultOrDefaultCommandInvoker<TResult> Create<TResult>(IFirstResultOrDefaultCommand<TResult> serviceCommand);
	}
}
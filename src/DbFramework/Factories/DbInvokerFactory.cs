using DbFramework.DbCommands;
using DbFramework.Interfaces.Factories;
using DbFramework.Interfaces.Invokers;
using DbFramework.Invokers;

namespace DbFramework.Factories
{
    public class DbInvokerFactory : IDbInvokerFactory
	{
		public INonQueryCommandInvoker Create(INonQueryCommand serviceCommand)
			=> new NonQueryCommandInvoker(serviceCommand);

		public INonQueryCommandInvoker<TResult> Create<TResult>(INonQueryCommand<TResult> serviceCommand) 
		    => new NonQueryCommandInvoker<TResult>(serviceCommand);

		public IFirstResultCommandInvoker<TResult> Create<TResult>(IFirstResultCommand<TResult> serviceCommand)
			=> new FirstResultCommandInvoker<TResult>(serviceCommand);

		public IFirstResultOrDefaultCommandInvoker<TResult> Create<TResult>(IFirstResultOrDefaultCommand<TResult> serviceCommand)
			=> new FirstResultOrDefaultCommandInvoker<TResult>(serviceCommand);

		public ISingleResultCommandInvoker<TResult> Create<TResult>(ISingleResultCommand<TResult> serviceCommand)
		    => new SingleResultCommandInvoker<TResult>(serviceCommand);

		public ISingleResultOrDefaultCommandInvoker<TResult> Create<TResult>(ISingleResultOrDefaultCommand<TResult> serviceCommand)
			=> new SingleResultOrDefaultCommandInvoker<TResult>(serviceCommand);

		public IManyResultCommandInvoker<TResult> Create<TResult>(IManyResultsCommand<TResult> serviceCommand)
		    => new ManyResultsCommandInvoker<TResult>(serviceCommand);

		public IScalarCommandInvoker<TResult> Create<TResult>(IScalarCommand<TResult> serviceCommand) 
		    => new ScalarCommandInvoker<TResult>(serviceCommand);

		public IDoesResultExistCommandInvoker Create(IDoesResultExistCommand serviceCommand) 
		    => new DoesResultExistCommandInvoker(serviceCommand);
	}
}
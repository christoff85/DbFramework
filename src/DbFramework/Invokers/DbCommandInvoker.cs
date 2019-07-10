using System;
using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
    internal abstract class DbCommandInvoker<TDbFrameworkCommand, TResult> 
	    : IDbFrameworkCommandInvoker<TResult> 
	    where TDbFrameworkCommand : IDbFrameworkCommand
    {
		protected TDbFrameworkCommand Command { get; }

        protected DbCommandInvoker(TDbFrameworkCommand command)
        {
			if (command == null) throw new ArgumentNullException(nameof(command));
			Command = command;
		}

	    public TResult Invoke(IDbManager dbManager)
	    {
		    if (dbManager == null) throw new ArgumentNullException(nameof(dbManager));

			var dbCommand = Command.GetDbCommandWithAssignedParameters(dbManager);
		    return Execute(dbManager, dbCommand);
	    }

        //public async Task<TResult> InvokeAsync(IDbManager dbManager, CancellationToken cancellationToken)
        //{
        //    if (dbManager == null) throw new ArgumentNullException(nameof(dbManager));

        //    var dbCommand = await Command.GetDbCommandWithAssignedParametersAsync(dbManager, cancellationToken);
        //    return await ExecuteAsync(dbManager, dbCommand, cancellationToken);
        //}

        protected abstract TResult Execute(IDbManager dbManager, IDbCommand command);
        //protected abstract Task<TResult> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken);
    }
}

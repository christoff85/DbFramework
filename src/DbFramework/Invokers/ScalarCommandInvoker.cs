using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
	internal class ScalarCommandInvoker<TResult>
        : DbCommandInvoker<IScalarCommand<TResult>, TResult>, IScalarCommandInvoker<TResult>
    {
        internal ScalarCommandInvoker(IScalarCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbManager dbManager, IDbCommand command)
	        => dbManager.ExecuteScalar<TResult>(command);

        //protected override async Task<TResult> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
        //    => await dbManager.ExecuteScalarAsync<TResult>(command, cancellationToken);
    }
}
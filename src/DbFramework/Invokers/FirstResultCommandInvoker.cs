using System;
using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
	internal class FirstResultCommandInvoker<TResult>
        : DbCommandInvoker<IFirstResultCommand<TResult>, TResult>, IFirstResultCommandInvoker<TResult>
    {
        internal FirstResultCommandInvoker(IFirstResultCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbManager dbManager, IDbCommand command)
        {
            using (var reader = dbManager.ExecuteReader(command))
                return GetFirstResult(reader);
        }

        //protected override async Task<TResult> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
        //{
        //    using (var reader = await dbManager.ExecuteReaderAsync(command, cancellationToken))
        //        return GetFirstResult(reader);
        //}

        private TResult GetFirstResult(IDbReader reader)
	    {
		    if (!reader.Read())
			    throw new InvalidOperationException("No results found");

	        return Command.MapResult(reader);

	    }
	}
}
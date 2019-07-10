using System;
using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
	internal class SingleResultCommandInvoker<TResult>
        : DbCommandInvoker<ISingleResultCommand<TResult>, TResult>, ISingleResultCommandInvoker<TResult>
    {
        internal SingleResultCommandInvoker(ISingleResultCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbManager dbManager, IDbCommand command)
        {
            using (var reader = dbManager.ExecuteReader(command))
                return GetSingleResult(reader);
        }

        //protected override async Task<TResult> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
        //{
        //    using (var reader = await dbManager.ExecuteReaderAsync(command, cancellationToken))
        //        return GetSingleResult(reader);
        //}

        private TResult GetSingleResult(IDbReader reader)
	    {
		    if (!reader.Read())
			    throw new InvalidOperationException("No results found");

		    var result = Command.MapResult(reader);

		    if (reader.Read())
			    throw new InvalidOperationException("Too many results");

			return result;
	    }
	}
}
using System;
using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
	internal class SingleResultOrDefaultCommandInvoker<TResult>
        : DbCommandInvoker<ISingleResultOrDefaultCommand<TResult>, TResult>, ISingleResultOrDefaultCommandInvoker<TResult>
    {
        internal SingleResultOrDefaultCommandInvoker(ISingleResultOrDefaultCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbManager dbManager, IDbCommand command)
        {
            using (var reader = dbManager.ExecuteReader(command))
                return GetSingleResultOrDefault(reader);
        }

        //protected override async Task<TResult> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
        //{
        //    using (var reader = await dbManager.ExecuteReaderAsync(command, cancellationToken))
        //        return GetSingleResultOrDefault(reader);
        //}

        private TResult GetSingleResultOrDefault(IDbReader reader)
	    {
		    if (!reader.Read())
				return default(TResult);

			var result = Command.MapResult(reader);

		    if (reader.Read())
			    throw new InvalidOperationException("Too many results");

		    return result;
	    }
	}
}
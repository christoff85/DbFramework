using System.Collections.Generic;
using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
    internal class ManyResultsCommandInvoker<TResult> 
        : DbCommandInvoker<IManyResultsCommand<TResult>, IEnumerable<TResult>>, IManyResultCommandInvoker<TResult>
    {
        internal ManyResultsCommandInvoker(IManyResultsCommand<TResult> command)
            : base(command)
        {
        }

        protected override IEnumerable<TResult> Execute(IDbManager dbManager, IDbCommand command)
        {
            using (var reader = dbManager.ExecuteReader(command))
                return GetManyResults(reader);
        }

        //protected override async Task<IEnumerable<TResult>> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
        //{
        //    using (var reader = await dbManager.ExecuteReaderAsync(command, cancellationToken))
        //        return GetManyResults(reader);
        //}

        private IEnumerable<TResult> GetManyResults(IDbReader reader)
	    {
		    var results = new List<TResult>();

		    while (reader.Read())
			    results.Add(Command.MapResult(reader));

		    return results;
	    }
	}
}
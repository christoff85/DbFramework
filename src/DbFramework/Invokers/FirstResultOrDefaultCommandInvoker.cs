using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
	internal class FirstResultOrDefaultCommandInvoker<TResult>
        : DbCommandInvoker<IFirstResultOrDefaultCommand<TResult>, TResult>, IFirstResultOrDefaultCommandInvoker<TResult>
    {
        internal FirstResultOrDefaultCommandInvoker(IFirstResultOrDefaultCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbManager dbManager, IDbCommand command)
        {
            using (var reader = dbManager.ExecuteReader(command))
                return GetFirstResultOrDefault(reader);
        }

        //protected override async Task<TResult> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
        //{
        //    using (var reader = await dbManager.ExecuteReaderAsync(command, cancellationToken))
        //        return GetFirstResultOrDefault(reader);
        //}

        private TResult GetFirstResultOrDefault(IDbReader reader)
	    {
		    return reader.Read() ? Command.MapResult(reader) : default(TResult);
	    }
	}
}
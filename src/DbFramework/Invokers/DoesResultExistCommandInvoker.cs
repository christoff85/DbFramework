using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
	internal class DoesResultExistCommandInvoker
        : DbCommandInvoker<IDoesResultExistCommand, bool>, IDoesResultExistCommandInvoker
    {
        internal DoesResultExistCommandInvoker(IDoesResultExistCommand command)
            : base(command)
        {
        }

        protected override bool Execute(IDbManager dbManager, IDbCommand command)
        {
            using (var reader = dbManager.ExecuteReader(command))
                return DoesResultExist(reader);
        }

        //protected override async Task<bool> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
        //{
        //    using (var reader = await dbManager.ExecuteReaderAsync(command, cancellationToken))
        //        return DoesResultExist(reader);
        //}

        private bool DoesResultExist(IDbReader reader)
		    => reader.Read() && Command.ResultContentChecker(reader);
	}
}
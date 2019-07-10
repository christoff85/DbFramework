using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
    internal class NonQueryCommandInvoker : DbCommandInvoker<INonQueryCommand, int>, INonQueryCommandInvoker
    {
        internal NonQueryCommandInvoker(INonQueryCommand dbServiceCommand)
            : base(dbServiceCommand)
        {
        }

        protected override int Execute(IDbManager dbManager, IDbCommand command)
            => dbManager.ExecuteNonQuery(command);

        //protected override async Task<int> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
        //    => await dbManager.ExecuteNonQueryAsync(command, cancellationToken);
    }
}
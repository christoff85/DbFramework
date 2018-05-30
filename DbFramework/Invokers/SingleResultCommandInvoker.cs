using System.Data;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
    public class SingleResultCommandInvoker<TResult>
        : DbServiceCommandInvoker<ISingleResultCommand<TResult>, TResult>, ISingleResultCommandInvoker<TResult>
    {
        internal SingleResultCommandInvoker(ISingleResultCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbServiceManager dbServiceManager, IDbCommand command)
        {
            using (var reader = dbServiceManager.ExecuteReader(command))
                return reader.GetSingleResult(Command.MapReaderToResult, Command.Options);
        }


    }
}
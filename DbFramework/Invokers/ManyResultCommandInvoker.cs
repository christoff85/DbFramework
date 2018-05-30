using System.Collections.Generic;
using System.Data;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
    public class ManyResultCommandInvoker<TResult> 
        : DbServiceCommandInvoker<IManyResultCommand<TResult>, IEnumerable<TResult>>, IManyResultCommandInvoker<TResult>
    {
        internal ManyResultCommandInvoker(IManyResultCommand<TResult> command)
            : base(command)
        {
        }

        protected override IEnumerable<TResult> Execute(IDbServiceManager dbServiceManager, IDbCommand command)
        {
            using (var reader = dbServiceManager.ExecuteReader(command))
                return reader.GetManyResults(Command.MapReaderToResult);
        }
    }
}
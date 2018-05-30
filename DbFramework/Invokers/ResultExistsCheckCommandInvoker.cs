using System.Data;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
    public class ResultExistsCheckCommandInvoker
        : DbServiceCommandInvoker<IResultExistsCheckCommand, bool>, IResultExistsCheckCommandInvoker
    {
        internal ResultExistsCheckCommandInvoker(IResultExistsCheckCommand command)
            : base(command)
        {
        }

        protected override bool Execute(IDbServiceManager dbServiceManager, IDbCommand command)
        {
            using (var reader = dbServiceManager.ExecuteReader(command))
                return reader.CheckIfResultExists(Command.ResultContentCheck);
        }


    }
}
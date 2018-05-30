using System.Data;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Interfaces.DbCommands
{
    public interface ICustomHandlerCommand<out TResult> : IDbServiceCommand
    {
        TResult CustomHandler(IDbServiceManager db, IDbCommand command);
    }
}
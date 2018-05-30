using System.Data;
using DbFramework.Interfaces.DbOperations;

namespace DbFramework.Interfaces.DbCommands
{
    public interface IManyResultCommand<out TResult> : IDbServiceCommand
    {
        TResult MapReaderToResult(IDataReader reader);
    }
}
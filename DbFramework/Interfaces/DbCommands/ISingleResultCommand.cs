using System.Data;
using DbFramework.Enums;
using DbFramework.Interfaces.DbOperations;

namespace DbFramework.Interfaces.DbCommands
{
    public interface ISingleResultCommand<out TResult> : IDbServiceCommand
    {
        SingleResultOptions Options { get; }
        TResult MapReaderToResult(IDataReader reader);
    }
}
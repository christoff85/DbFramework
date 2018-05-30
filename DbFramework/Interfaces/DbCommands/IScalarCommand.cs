using DbFramework.Interfaces.DbOperations;

namespace DbFramework.Interfaces.DbCommands
{
    public interface IScalarCommand<TResult> : IDbServiceCommand
    {
    }
}
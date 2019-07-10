using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
    public interface ISingleResultCommand<out TResult> : IDbFrameworkCommand
    {
        TResult MapResult(IDbReader reader);
    }
}
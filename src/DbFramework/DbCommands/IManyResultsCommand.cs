using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
    public interface IManyResultsCommand<out TResult> : IDbFrameworkCommand
    {
        TResult MapResult(IDbReader reader);
    }
}
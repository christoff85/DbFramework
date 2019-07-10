using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
    public interface IFirstResultCommand<out TResult> : IDbFrameworkCommand
    {
        TResult MapResult(IDbReader reader);
    }
}
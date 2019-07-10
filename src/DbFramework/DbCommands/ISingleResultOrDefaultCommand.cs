using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
    public interface ISingleResultOrDefaultCommand<out TResult> : IDbFrameworkCommand
    {
        TResult MapResult(IDbReader reader);
    }
}
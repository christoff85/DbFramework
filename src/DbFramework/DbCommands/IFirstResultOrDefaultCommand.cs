using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
    public interface IFirstResultOrDefaultCommand<out TResult> : IDbFrameworkCommand
    {
        TResult MapResult(IDbReader reader);
    }
}
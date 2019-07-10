namespace DbFramework.DbCommands
{
    public interface INonQueryCommand<out TResult> : IDbFrameworkCommand
    {
        TResult MapOutParametersToResult();
    }
}